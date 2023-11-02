using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameManager : MonoBehaviour
{
    public GameObject SceneMenu;
    public AudioSource s;

    // gigglez
    public AudioClip[] giggles;
    public bool giggles_b = false;

    //this function plays the audio clip then checks to see if
    //the audio has finished playing in a coroutine.
    public void ActivateMenuOnFinish(AudioClip clip, float delay)
    {
        StartCoroutine(WaitForClip(clip, delay));
    }
    IEnumerator WaitForClip(AudioClip clip, float delay)
    {
        //the clip will play after delay
        yield return new WaitForSeconds(delay);
        s.clip = clip;
        s.PlayOneShot(clip);
        
        //set SceneMenu to appear if clip finishes
        while (s.isPlaying != false)
        {
            yield return new WaitForSeconds(.2f);
        }
        SceneMenu.SetActive(true);
        yield return null;
    }
    protected IEnumerator PlayAudioClipDelayed(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        s.PlayOneShot(clip);
    }
}
