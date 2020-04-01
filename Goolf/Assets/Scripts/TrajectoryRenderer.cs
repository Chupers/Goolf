using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 direction)
    {

        Vector3[] points = new Vector3[100];
        lineRenderer.positionCount = points.Length;

        for(int i = 0; i < points.Length;i++)
        {
            float time = i * 0.1f;
            points[i] = origin + direction * time + Physics.gravity * time * time / 2f;

            if(points[i].y < 0)
            {
                lineRenderer.positionCount = i + 1;
                break;
            }
        }

        lineRenderer.SetPositions(points);
    }
}
