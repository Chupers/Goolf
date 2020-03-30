using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    public GameObject gameObject;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 vector, Vector3 direction)
    {
        GameObject gameObject = Instantiate(this.gameObject, vector, Quaternion.identity);
        gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized, ForceMode.VelocityChange);

        Physics.autoSimulation = false;

        //simulation

        Vector3[] points = new Vector3[100];

        for(int i = 0; i < points.Length;i++)
        {
            Physics.Simulate(0.1f);
            points[i] = gameObject.transform.position;
        }

        lineRenderer.SetPositions(points);

        Physics.autoSimulation = true;

        Destroy(gameObject);

    }
}
