using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHover : MonoBehaviour
{
    public float amplitude = .5f;
    public float speed = 1f;

    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + amplitude * Vector3.up * Mathf.Sin(speed * Time.time);
    }

}
