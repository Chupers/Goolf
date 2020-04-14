using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewboll : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        //Chuper dupers
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(gameObject);
        }
    }
}
