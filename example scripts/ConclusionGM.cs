using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConclusionGM : MonoBehaviour
{
    public Image cover;

    public AudioClip Ending;

    private AudioSource audioSource;

    public GameObject player;

    Transform RobotTransform;
    public GameObject Robot;

    public GameObject DrunkTime;

    public GameObject creditRoll;

    // Start is called before the first frame update
    void Start()
    {
        DrunkTime.GetComponent<DRUNK>().enabled = false;
        creditRoll.SetActive(false);
        StartCoroutine(unfade());
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(Credits(13f));

        StartCoroutine(PlayAudioClipDelayed(Ending, 1f));

        RobotTransform = Robot.transform;
        Vector3 RobotPos = RobotTransform.position;
    }

    private IEnumerator PlayAudioClipDelayed(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(clip);
        yield return null;
    }

    IEnumerator unfade()
    {
        cover.gameObject.SetActive(true);
        cover.CrossFadeAlpha(0, 2.0f, false);
        yield return null;
    }

    IEnumerator Credits(float delay) {
        yield return new WaitForSeconds(delay);
        creditRoll.SetActive(true);
    }


    
}
