using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float leangth, startpos;
    public GameObject cam;
    public float parallalEffect;

    void Start()
    {
        startpos = transform.position.x;
        leangth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

   
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallalEffect));
        float dist = (cam.transform.position.x * parallalEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + leangth) startpos += leangth;
        else if (temp < startpos - leangth) startpos -= leangth;
    }
}
