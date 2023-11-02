using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsCheckR2 : MonoBehaviour
{

    public GameObject[] NeededObjs;

    public int objsIn;

    // Start is called before the first frame update
    void Start()
    {
        objsIn = 0;
    }

    void OnCollisionEnter(Collision collide)
    {
        Debug.Log(collide.gameObject.ToString());
        foreach(GameObject g in NeededObjs)
        {
            if(collide.gameObject==g)
            {
                objsIn++;
            }
        }
    }

    void OnCollisionExit(Collision collide)
    {
        foreach (GameObject g in NeededObjs)
        {
            if (collide.gameObject == g)
            {
                objsIn--;
            }
        }
    }
}
