using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDaddyGM : MonoBehaviour
{
    public bool Reaction1;
    public bool Reaction2;
    public bool Reaction3;
    public bool Conclusion;

    public GameObject r1;
    public GameObject r2;
    public GameObject r3;
    public GameObject conc;

    // Start is called before the first frame update
    void Start()
    {
        Reaction1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Reaction1 == true) {
            r1.SetActive(true);
        }

        if(Reaction2 == true) {
            r2.SetActive(true);
            r1.SetActive(false);
        }

        if(Reaction3 == true) {
            r3.SetActive(true);
            r2.SetActive(false);
        }

        if(Conclusion == true) {
            conc.SetActive(true);
            r3.SetActive(false);
        }
    }
}
