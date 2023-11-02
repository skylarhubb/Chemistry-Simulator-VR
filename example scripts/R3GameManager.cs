using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class R3GameManager : BaseGameManager
{
    // audio clips
    public AudioClip audioClip3_1;
    public AudioClip audioClip3_2;
    public AudioClip audioClip3_3;
    public AudioClip audioClip3_4;
    public AudioClip audioClip3_5;
    public AudioClip audioClip3_6;
    public AudioClip audioClip3_7;
    public AudioClip audioClip3_8;
    public AudioClip audioClip3_9;

    public AudioClip[] audioClipQRAs;

    private AudioSource audioSource;

    // references to checkpoints
    public bool TabsAdded = false;
    public bool HotPlateOn = false; 
    public bool sodium_bromide_Added = false; // think we can scrap this?
    public bool sodium_bromide_inFlask = false;
    public bool mixture_added = false; // and this?
    public bool all_chemicals_added = false;

    // ensuring each audio clip is only played once
    public bool audioClip3_1b;
    public bool audioClip3_2b;
    public bool audioClip3_3b;
    public bool audioClip3_4b;
    public bool audioClip3_5b;
    public bool audioClip3_6b;
    public bool audioClip3_7b;
    public bool audioClip3_8b;
    public bool audioClip3_9b;

    // for the QRAs
    public bool qra1 = false;
    public bool qra2 = false;
    public bool qra3 = false;
    public bool qra4 = false;

    // references for  liquids
    public GameObject NaBrBeakerLiq;
    public GameObject BigFlaskLiq1;
    public GameObject BigFlaskLiq2;
    public GameObject SolutionBeakerLiq;
    public GameObject Tablets;
    public GameObject BromineLiq;

    // reference to camera shake
    public GameObject DrunkTime;

    public Image cover;

    // to swtich scenes
    public string nextSceneName;

    // for bromine floaty
    public GameObject BromineFloater;
    public GameObject BromineGas;

    // for ending
    public BigDaddyGM sceneSwitcher;
    public GameObject player; 
    Vector3 newPosition;
    public Transform CameraTransform;
    public GameObject Camera;
    public Vector3 CameraPos;

    void Start()
    {
        StartCoroutine(unfadeOpen());
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator unfadeOpen()
    {
        cover.gameObject.SetActive(true);
        cover.CrossFadeAlpha(0, 2.0f, false);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if(giggles_b) {
            AudioClip gigs = giggles[Random.Range(0, giggles.Length)];
            StartCoroutine(PlayAudioClipDelayed(gigs, .1f));
            giggles_b = false;
        }

        if(!audioClip3_1b) {
            StartCoroutine(PlayAudioClipDelayed(audioClip3_1, .5f));
            audioClip3_1b = true;
        }

        if(!audioClip3_2b) {
            StartCoroutine(PlayAudioClipDelayed(audioClip3_2, 13f));
            audioClip3_2b = true;
        }

        if(!audioClip3_3b) {
            StartCoroutine(PlayAudioClipDelayed(audioClip3_3, 33f));
            audioClip3_3b = true;
        }

        if(TabsAdded == true) {
            AudioClip q1 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
            if(!qra1) {
                StartCoroutine(PlayAudioClipDelayed(q1, .1f));
                qra1 = true;
            }
            if(!audioClip3_4b) {
                StartCoroutine(PlayAudioClipDelayed(audioClip3_4, 2f));
                audioClip3_4b = true;
            }

            if(HotPlateOn == true) {
                AudioClip q2 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                if(!qra2) {
                    StartCoroutine(PlayAudioClipDelayed(q2, .1f));
                    qra2 = true;
                }
                if(!audioClip3_5b) {
                    StartCoroutine(PlayAudioClipDelayed(audioClip3_5, 2f));
                    audioClip3_5b = true;
                }

                if(sodium_bromide_inFlask == true) {
                    // empty liquid from nabr thing
                    NaBrBeakerLiq.SetActive(false);

                    // add liquid to big flask
                    BigFlaskLiq1.SetActive(true);

                    // deactivate tablets
                    Tablets.SetActive(false);
                    
                    AudioClip q3 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                    if(!qra3) {
                        StartCoroutine(PlayAudioClipDelayed(q3, .1f));
                        qra3 = true;
                    }
                    if(!audioClip3_6b) {
                        StartCoroutine(PlayAudioClipDelayed(audioClip3_6, 2f));
                        audioClip3_6b = true;
                    }

                    if(mixture_added == true) {
                        SolutionBeakerLiq.SetActive(false);
                        BigFlaskLiq1.SetActive(false);
                        BigFlaskLiq2.SetActive(true);

                        AudioClip q4 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                        if(!qra4) {
                            StartCoroutine(PlayAudioClipDelayed(q4, .1f));
                            qra4 = true;
                        }
                        if(!audioClip3_7b) {
                            StartCoroutine(PlayAudioClipDelayed(audioClip3_7, 2f));
                            StartCoroutine(StartFadeDelayed(13f));
                            audioClip3_7b = true;
                        }

                        if(all_chemicals_added == true) {
                            // change bromine tube color 
                            BromineLiq.SetActive(true);

                            if(!audioClip3_8b) {
                                StartCoroutine(PlayAudioClipDelayed(audioClip3_8, .5f));
                                audioClip3_8b = true;
                            }

                            if(!audioClip3_9b) {
                                StartCoroutine(PlayAudioClipDelayed(audioClip3_9, 6f));
                                // make the bromine tube float towards user
                                // basically make tubefloat.floating = true
                                // start the 'drunk' animation
                                StartCoroutine(UhOh(12f));
                                StartCoroutine(WaitToKill(9f));
                                BromineGas.SetActive(true);
                                StartCoroutine(SwitchScenes(15f));
                                audioClip3_9b = true;
                            }
                        }
                    }
                }
            }
        }
        
    }

    //this function is called when all_chemicals_added is true
    public void FadeToBlack()
    {
        // cover.SetActive(true);
        // StartCoroutine(ftb());
        StartCoroutine(fade());
        StartCoroutine(unfade());

    }

    IEnumerator unfade()
    {
        yield return new WaitForSeconds(3f);
        cover.gameObject.SetActive(true);
        cover.CrossFadeAlpha(0, 2.0f, false);
        all_chemicals_added = true;
    }

    IEnumerator fade()
    {
        cover.gameObject.SetActive(true);
        cover.CrossFadeAlpha(1, 2.0f, false);
        yield return null;
    }

    private IEnumerator PlayAudioClipDelayed(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(clip);
    }

    private IEnumerator HighlightObj(GameObject obj) {
        yield return new WaitForSeconds(5f);
        obj.GetComponent<Outline>().enabled = true;
    }

    void UnhighlightObj(GameObject obj) {
        obj.GetComponent<Outline>().enabled = false;
        StopCoroutine(HighlightObj(obj));
    }

    private IEnumerator StartFadeDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        FadeToBlack();
    }

    private IEnumerator SwitchScenes(float delay) {
        yield return new WaitForSeconds(delay); 
        CameraTransform = Camera.transform;
        CameraPos = CameraTransform.position;
        newPosition = new Vector3(CameraPos.x - 20f, CameraPos.y-2f, CameraPos.z+.3f);
        player.transform.position = newPosition;
        sceneSwitcher.Conclusion = true;
    }

    private IEnumerator WaitToKill(float delay) {
        yield return new WaitForSeconds(delay);
        BromineFloater.GetComponent<BromineFloaty>().enabled = true;
    }

    private IEnumerator UhOh(float delay) {
        yield return new WaitForSeconds(delay);
        DrunkTime.GetComponent<DRUNK>().enabled = true;
    }
}
