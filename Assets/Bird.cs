using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    float Fspeed = 5.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Fspeed * Time.deltaTime);

        if (transform.position.x < -60f)
        {
            Destroy(gameObject);
        }
    }
}