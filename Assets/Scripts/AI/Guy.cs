using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    public Transform target;
    public float speed = 7f;
    public Rigidbody rig;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rig.velocity = new Vector3(0f, 0f, -speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Door")
        {
            speed = 0f;
            Invoke("Resume", 1f);
            collision.gameObject.GetComponentInParent<Door>().Open();
        }
        else if (collision.gameObject.name == "Target")
            speed = 0f;

    }

    void Resume()
    {
        speed = 10f;
    }
}
