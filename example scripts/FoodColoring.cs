using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodColorDropper : MonoBehaviour
{
    public GameObject colorBlob;
    public Transform spawnPoint;
    public float dropSpeed = .00000001f;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(DropColor);
    }

    public void DropColor(ActivateEventArgs arg)
    {
        GameObject spawnedBlob = Instantiate(colorBlob);
        spawnedBlob.transform.position = spawnPoint.position;
        spawnedBlob.GetComponent<Rigidbody>().velocity = Vector3.down * dropSpeed;
        Destroy(spawnedBlob, 10);
    }
}



