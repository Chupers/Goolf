using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAction : MonoBehaviour
{
    Rigidbody rigidbody;
    public float forse = 50f;
    private TrajectoryRenderer Trajectory;
    Vector3 direction;
    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                targetPosition = hitInfo.point;
                direction = rigidbody.transform.position - targetPosition;
                Trajectory.ShowTrajectory(transform.position, direction.normalized * forse);
            }
            if (Input.GetMouseButtonUp(0))
            {
                rigidbody.AddForce(direction.normalized * forse, ForceMode.VelocityChange);

            }
        }
    }
}
