using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAction : MonoBehaviour
{
    Rigidbody rigidbody;
    public float forse = 50f;
    public TrajectoryRenderer trajectoryRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetInput())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                
                Vector3 targetPosition = hitInfo.point;
                Vector3 direction = rigidbody.transform.position - targetPosition * forse;
                trajectoryRenderer.ShowTrajectory(transform.position, direction);
                rigidbody.AddForce(direction.normalized, ForceMode.VelocityChange);
            }
        }
    }
    private bool GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }
}
