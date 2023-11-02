using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletTrig : MonoBehaviour
{
    public R3GameManager r3gm;
    public int count;

    void OnTriggerEnter(Collider other) {

        if(other.tag == "Tablet") {
            count++;

            if(count >= 6) {
                r3gm.TabsAdded = true;
            }
        }

        if(other.tag == "MainCamera") {
            if((r3gm.TabsAdded) && (!r3gm.HotPlateOn)) {
                r3gm.HotPlateOn = true;
            }
        }
        if (other.tag == "Hands")
        {
            if ((r3gm.TabsAdded) && (!r3gm.HotPlateOn))
            {
                r3gm.HotPlateOn = true;
            }
        }

        else {
            Debug.Log(other.tag);
        }
    }
}
