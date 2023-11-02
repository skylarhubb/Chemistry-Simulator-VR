using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public AudioSource sound;
    bool initSound = true;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision collision)
    {   
        if (initSound)
        {
            initSound= false;
        }
        else
        {
            Debug.Log(collision.ToString());
            sound.Play();
        }
    }
}
