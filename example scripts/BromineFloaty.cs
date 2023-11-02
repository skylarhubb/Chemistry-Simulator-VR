using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BromineFloaty : MonoBehaviour
{
    public float floatSpeed = 1.0f;
    public Transform userTransform;
    public float distanceFromUser = 2.0f;
    public float heightOffset = -0.5f;

    void Update()
    {
        if (userTransform == null)
        {
            Debug.LogError("User transform is not set.");
            return;
        }

        // calculate position
        Vector3 targetPosition = userTransform.position + userTransform.forward * distanceFromUser + Vector3.up * heightOffset;

        // calculate direction
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();

        // move beaker towards the target position
        transform.position += direction * floatSpeed * Time.deltaTime;
    
    }
}
