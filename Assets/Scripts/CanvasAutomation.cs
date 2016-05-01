using UnityEngine;
using System.Collections.Generic;
using Leap;
using System;

public class CanvasAutomation : MonoBehaviour {

	public Material material_;

  private const int INTERPOLATION_AMT = 3;
  private const int MAX_POINTS = 400;
  private const int POINT_MEMORY = 4;
  private const int TUBE_FACES = 5;
  private const int VERTEX_NUM = TUBE_FACES * 2;
  private const int TRIANGLE_NUM = TUBE_FACES * 6;
  private const float MULTI_HAND_PHASE = 0.1f;
	
	private Mesh mesh_;

  private int point_index_ = 0;

	private float line_width_ = 0.6f;
	private float current_line_width_ = 0.0f;
  private float multi_hand_phase_ = 0.0f;

  private Vector3 last_velocity_;
  private Vector3 last_drawn_point_;
  private Vector3[] drawn_points_;
  private Vector3[] last_points_;
  private Vector3[] last_shape_;

  private bool drawing_;
  private bool looping_mode_;
  private List<Vector3> next_points_;

	void Start () {
		mesh_ = new Mesh();
    looping_mode_ = true;
    drawing_ = false;

    next_points_ = new List<Vector3>();
    drawn_points_ = new Vector3[MAX_POINTS];
    last_points_ = new Vector3[POINT_MEMORY];
    last_shape_ = null;
	}
  
  private Vector3 InterpolatedPoint(float t) {
    Vector3 naut = last_points_[0] * (t + 2) * (t + 1) * t / 6.0f;
    Vector3 one = -last_points_[1] * (t + 2) * (t + 1) * (t - 1) / 2.0f;
    Vector3 two = last_points_[2] * (t + 2) * t * (t - 1) / 2.0f;
    Vector3 three = -last_points_[3] * (t + 1) * t * (t - 1) / 6.0f;
    
    return naut + one + two + three;
  }

  public void AddNextPoint(Vector3 next) {
    if (!drawing_) {
      for (int i = 0; i < POINT_MEMORY; ++i)
        last_points_[i] = next;
      last_drawn_point_ = next;
      last_velocity_ = Vector3.zero;
    }

    next_points_.Add(next);
    drawing_ = true;
  }

  private void UpdateNextPoint() {
    if (drawing_) {
      for (int i = POINT_MEMORY - 1; i > 0; i--)
        last_points_[i] = last_points_[i - 1];

      Vector3 point1 = next_points_[0];
      Vector3 point2 = next_points_[1 % next_points_.Count];
      float t = Mathf.Sin(multi_hand_phase_) / 2.0f + 0.5f;
      last_points_[0] = point1 + t * (point2 - point1);
      multi_hand_phase_ += MULTI_HAND_PHASE;
      next_points_.Clear();
    }

    for (int i = 1; i <= INTERPOLATION_AMT; ++i) {
      if (looping_mode_ || drawing_)
        IncrementIndices();

      Vector3 draw_point = InterpolatedPoint((1.0f * i) / INTERPOLATION_AMT);
      last_velocity_ = last_velocity_ + 0.4f * (draw_point - last_drawn_point_ - last_velocity_);

      if (drawing_) {
        last_shape_ = MakeShape(draw_point);
        AddLine(mesh_, last_shape_);
        drawn_points_[point_index_] = draw_point;
      }
      else {
        last_shape_ = null;
        current_line_width_ = 0.0f;
      }
      material_.SetFloat("_Phase", (1.0f * MAX_POINTS - point_index_ - 1) / MAX_POINTS);
      last_drawn_point_ = draw_point;
    }
  }

  public Vector3 GetLastPoint() {
    return drawn_points_[point_index_];
  }

  void IncrementIndices() {
    point_index_ = (point_index_ + 1) % MAX_POINTS;
  }

	void LateUpdate() {
    drawing_ = next_points_.Count != 0;

    UpdateNextPoint();
		Graphics.DrawMesh(mesh_, transform.localToWorldMatrix, material_, 0);
		processInput();
	}
	
	Vector3[] MakeShape(Vector3 next) {
		Vector3[] q = new Vector3[VERTEX_NUM];

    float compute_width = (1.0f / (40 * last_velocity_.magnitude + 1.0f)) * line_width_;
    current_line_width_ = current_line_width_ + 0.1f * (compute_width - current_line_width_);
    Vector3 radius = new Vector3(0.0f, current_line_width_ / 2.0f, 0.0f);
    Quaternion rotation = Quaternion.AngleAxis(360.0f / TUBE_FACES, new Vector3(0, 0, 1));

    if (last_shape_ == null) {
      for (int i = 0; i < TUBE_FACES; ++i)
        q[i] = transform.InverseTransformPoint(last_drawn_point_);
    }
    else {
      for (int i = 0; i < TUBE_FACES; ++i)
        q[i] = transform.InverseTransformPoint(last_shape_[TUBE_FACES + i]);
    }
    for (int i = 0; i < TUBE_FACES; ++i) {
      q[TUBE_FACES + i] = transform.InverseTransformPoint(next + radius);
      radius = rotation * radius;
    }

		return q;
	}
	
	void AddLine(Mesh m, Vector3[] shape) {
    int vertex_index = point_index_ * VERTEX_NUM;
    int triangle_index = point_index_ * TRIANGLE_NUM;
    // Update Vertices.
    Vector3[] vertices = m.vertices;
    Color[] colors = m.colors;
    if (vertex_index >= m.vertices.Length) {
      Array.Resize(ref vertices, MAX_POINTS * VERTEX_NUM);
      Array.Resize(ref colors, MAX_POINTS * VERTEX_NUM);
    }

    for (int i = 0; i < VERTEX_NUM; ++i) {
      vertices[vertex_index + i] = shape[i];
      float t = (1.0f * vertex_index + i) / (MAX_POINTS * VERTEX_NUM);
      colors[vertex_index + i] = t * Color.red;
    }

    // Update triangles.
    int[] triangles = m.triangles;
    if (triangle_index >= m.triangles.Length)
      Array.Resize(ref triangles, MAX_POINTS * TRIANGLE_NUM);

    for (int i = 0; i < TUBE_FACES; ++i) {
      int t_index = triangle_index + i * 6;
      triangles[t_index] = vertex_index + i;
      triangles[t_index + 1] = vertex_index + i + TUBE_FACES;
      triangles[t_index + 2] = vertex_index + (i + 1) % TUBE_FACES;
      triangles[t_index + 3] = vertex_index + TUBE_FACES + (i + 1) % TUBE_FACES;
      triangles[t_index + 4] = vertex_index + (i + 1) % TUBE_FACES;
      triangles[t_index + 5] = vertex_index + i + TUBE_FACES;
    }

    m.vertices = vertices;
    m.colors = colors;
    m.triangles = triangles;
    m.RecalculateBounds();
	}
	
	void processInput() {
		if(Input.GetKeyDown(KeyCode.Space))
      looping_mode_ = !looping_mode_;
	}
}
