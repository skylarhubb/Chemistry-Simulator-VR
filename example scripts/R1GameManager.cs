using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R1GameManager : BaseGameManager
{
    public Image cover;

    public AudioClip IntroClip;
    public AudioClip audioClip1_1;
    public AudioClip audioClip1_1_1;
    public AudioClip audioClip1_2;
    public AudioClip audioClip1_3;
    public AudioClip audioClip1_4;
    public AudioClip audioClip1_5;
    public AudioClip audioClip1_6;
    public AudioClip audioClip1_65;
    public AudioClip audioClip1_7;
    public AudioClip audioClip1_8;
    public AudioClip audioClip1_9;
    public AudioClip audioClip1_10;
    public AudioClip audioClip1_11;

    public AudioClip[] audioClipQRAs;

    private AudioSource audioSource;

    // object references
    public bool AllObjectsIn;
    public bool PeroxideInMeasuringCylinder;
    public bool MeasuringCylinderInBeaker1;
    public bool Beaker1InBowl;
    public bool DishLiqInBeaker1;
    
    public bool RedDyeInBeaker1;
    public bool RedWaterCylInBeaker2;
    public bool RedYeastInBeaker2;
    public bool RedBeaker2InBeaker1;

    public bool beaker1complete;
    public bool beaker2complete;
    public bool reactionComplete;

    // ensuring audio clip is only played once
    public bool audioClip1_1b = false;
    public bool audioClip1_1_1b = false;
    public bool audioClip1_2b = false;
    public bool audioClip1_3b = false;
    public bool audioClip1_4b = false;
    public bool audioClip1_5b = false;
    public bool audioClip1_6b = false;
    public bool audioClip1_65b = false;
    public bool audioClip1_7b = false;
    public bool audioClip1_8b = false;
    public bool audioClip1_9b = false;
    public bool audioClip1_10b = false;
    public bool audioClip1_11b = false;

    // for da QRAs
    public bool qra1 = false;
    public bool qra2 = false;
    public bool qra3 = false;
    public bool qra4 = false;
    public bool qra5 = false;
    public bool qra6 = false;
    public bool qra7 = false;
    public bool qra8 = false;

    // for toggling active state of table glow area
    public GameObject areaToggle;

    // for highlighting objects that are being referenced
    public GameObject obj_peroxide;
    public GameObject obj_tallMC;
    public GameObject obj_beaker2; //large beaker
    public GameObject obj_beaker1; //small beaker
    public GameObject obj_bowl;
    public GameObject obj_dishsoap;

    public GameObject obj_red;
    
    public GameObject obj_water;
    public GameObject obj_yeast;

    // for the liquid transfers
    public GameObject TallMCLiq;
    public GameObject LargeBeakerLiq;
    public GameObject LargeBeakerLiqRed;
    public GameObject SmallBeakerLiq;
    public GameObject SmallBeakerLiqYeasty;
    public GameObject WaterCylLiq;
    public GameObject UhhhYeastLiq;

    //for particles to play at end of scene
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(unfade());
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlayAudioClipDelayed(IntroClip, 1f));
        //ActivateMenuOnFinish(IntroClip);  //if you want to test the menu at the start
        areaToggle.SetActive(false);

        StartCoroutine(ToggleGlowArea(22f));

    }
    IEnumerator unfade()
    {
        cover.gameObject.SetActive(true);
        cover.CrossFadeAlpha(0, 2.0f, false);
        yield return null;
    }
    void Update()
    {
        if(giggles_b) {
            AudioClip gigs = giggles[Random.Range(0, giggles.Length)];
            StartCoroutine(PlayAudioClipDelayed(gigs, .1f));
            giggles_b = false;
        }

        if(!audioClip1_1b) {
            StartCoroutine(PlayAudioClipDelayed(audioClip1_1, 7.5f));
            audioClip1_1b = true;
        }

        if(!audioClip1_1_1b) {
            StartCoroutine(PlayAudioClipDelayed(audioClip1_1_1, 22f));
            audioClip1_1_1b = true;
        }

        if(!audioClip1_2b) {
            StartCoroutine(PlayAudioClipDelayed(audioClip1_2, 26f));
            audioClip1_2b = true;
        }

        if(AllObjectsIn == true) {
            if (!audioClip1_3b) {
                StartCoroutine(PlayAudioClipDelayed(audioClip1_3, .5f));
                // making sure all of the highlights start off
                UnhighlightObj(obj_peroxide);
                UnhighlightObj(obj_tallMC);
                UnhighlightObj(obj_beaker2);
                UnhighlightObj(obj_beaker1);
                UnhighlightObj(obj_bowl);
                UnhighlightObj(obj_dishsoap);

                UnhighlightObj(obj_red);
                
                UnhighlightObj(obj_water);
                UnhighlightObj(obj_yeast);
                audioClip1_3b = true;
                areaToggle.SetActive(false);
            }
            if (!audioClip1_4b) {
                StartCoroutine(PlayAudioClipDelayed(audioClip1_4, 5f)); 
                StartCoroutine(HighlightObj(obj_peroxide));
                StartCoroutine(HighlightObj(obj_tallMC));
                audioClip1_4b = true;
            }

            if(PeroxideInMeasuringCylinder == true) {//
                UnhighlightObj(obj_peroxide);
                UnhighlightObj(obj_tallMC);

                // fill up cylinder with liquid***
                AudioClip q1 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                if(!qra1) {
                    StartCoroutine(PlayAudioClipDelayed(q1, .1f));
                    qra1 = true;
                    audioClip1_5b = false;
                }
                if(!audioClip1_5b) {
                    StartCoroutine(PlayAudioClipDelayed(audioClip1_5, 2f));
                    StartCoroutine(HighlightObj(obj_tallMC));
                    StartCoroutine(HighlightObj(obj_beaker2));
                    audioClip1_5b = true;
                }
                

                if(MeasuringCylinderInBeaker1 == true) {
                    UnhighlightObj(obj_tallMC);
                    UnhighlightObj(obj_beaker2);

                    // empty liquid from cylinder***
                    // fill up beaker with liquid***
                    TallMCLiq.SetActive(false);
                    LargeBeakerLiq.SetActive(true);

                    AudioClip q2 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                    if(!qra2) {
                        StartCoroutine(PlayAudioClipDelayed(q2, .1f));
                        qra2 = true;
                    }
                    if(!audioClip1_6b) {
                        StartCoroutine(PlayAudioClipDelayed(audioClip1_6, 2f));
                        StartCoroutine(HighlightObj(obj_beaker2));
                        StartCoroutine(HighlightObj(obj_bowl));
                        audioClip1_6b = true;
                    }
                

                    if(Beaker1InBowl == true) {
                        UnhighlightObj(obj_beaker2);
                        UnhighlightObj(obj_bowl);

                        AudioClip q3 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                        if(!qra3) {
                            StartCoroutine(PlayAudioClipDelayed(q3, .1f));
                            qra3 = true;
                        }
                        if(!audioClip1_65b) {
                            StartCoroutine(PlayAudioClipDelayed(audioClip1_65, 2f));
                            StartCoroutine(HighlightObj(obj_dishsoap));
                            StartCoroutine(HighlightObj(obj_beaker2));
                            audioClip1_65b = true;
                        }

                        if(DishLiqInBeaker1 == true) {//
                            UnhighlightObj(obj_dishsoap);
                            UnhighlightObj(obj_beaker2);

                            AudioClip q4 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            if(!qra4) {
                                StartCoroutine(PlayAudioClipDelayed(q4, .1f));
                                qra4 = true;
                            }
                            if(!audioClip1_7b) {
                                StartCoroutine(PlayAudioClipDelayed(audioClip1_7, 2f));
                                StartCoroutine(HighlightObj(obj_red));
                                StartCoroutine(HighlightObj(obj_beaker2));
                                audioClip1_7b = true;
                            }

                            if(RedDyeInBeaker1 == true) {
                                UnhighlightObj(obj_red);
                                UnhighlightObj(obj_beaker2);

                                LargeBeakerLiq.SetActive(false);
                                LargeBeakerLiqRed.SetActive(true);

                                AudioClip q5 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                                if(!qra5) {
                                    StartCoroutine(PlayAudioClipDelayed(q5, .1f));
                                    qra5 = true;
                                }
                                if(!audioClip1_8b) {
                                    StartCoroutine(PlayAudioClipDelayed(audioClip1_8, 2f));
                                    StartCoroutine(HighlightObj(obj_beaker1));
                                    StartCoroutine(HighlightObj(obj_water));
                                    audioClip1_8b = true;
                                }
                                
                                if(RedWaterCylInBeaker2 == true) {//
                                    UnhighlightObj(obj_beaker1);
                                    UnhighlightObj(obj_water);

                                    WaterCylLiq.SetActive(false);
                                    SmallBeakerLiq.SetActive(true);
                                    
                                    // empty liquid from water cylinder
                                    // fill up beaker with liquid
                                    AudioClip q6 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                                    if(!qra6) {
                                        StartCoroutine(PlayAudioClipDelayed(q6, .1f));
                                        qra6 = true;
                                    }
                                    if(!audioClip1_9b) {
                                        StartCoroutine(PlayAudioClipDelayed(audioClip1_9, 2f));
                                        StartCoroutine(HighlightObj(obj_yeast));
                                        StartCoroutine(HighlightObj(obj_beaker1));
                                        audioClip1_9b = true;
                                    }

                                    if(RedYeastInBeaker2 == true) {//
                                        UnhighlightObj(obj_beaker1);
                                        UnhighlightObj(obj_yeast);

                                        UhhhYeastLiq.SetActive(false);
                                        SmallBeakerLiq.SetActive(false);
                                        SmallBeakerLiqYeasty.SetActive(true);
                                        // empty yeast from bowl
                                        // change liquid in beaker 2 to murky tan
                                        if(!audioClip1_10b) {
                                            StartCoroutine(PlayAudioClipDelayed(audioClip1_10, .1f));
                                            StartCoroutine(HighlightObj(obj_beaker1));
                                            StartCoroutine(HighlightObj(obj_beaker2));
                                            audioClip1_10b = true;
                                        }

                                        if(RedBeaker2InBeaker1 == true) {//
                                            UnhighlightObj(obj_beaker1);
                                            UnhighlightObj(obj_beaker2);
                                            particle1.Play();
                                            particle2.Play();
                                            particle3.Play();
                                            SmallBeakerLiqYeasty.SetActive(false);
                                            // play red reaction particle simulation
                                            if(!audioClip1_11b) {
                                                ActivateMenuOnFinish(audioClip1_11, 2f);
                                                audioClip1_11b = true;
                                            }
                                        }
                                    }
                                }
                            }

                            // if(BlueDyeInBeaker1 == true) {
                            //     AudioClip q5 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            //     if(!qra5) {
                            //         StartCoroutine(PlayAudioClipDelayed(q5, .1f));
                            //         qra5 = true;
                            //     }
                            //     if(!audioClip1_8b) {
                            //         StartCoroutine(PlayAudioClipDelayed(audioClip1_8, 2f));
                            //         audioClip1_8b = true;
                            //     }
                                
                            //     if(BlueWaterCylInBeaker2 == true) {
                            //         // empty liquid from water cylinder
                            //         // fill up beaker with liquid
                            //         AudioClip q6 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            //         if(!qra6) {
                            //             StartCoroutine(PlayAudioClipDelayed(q6, .1f));
                            //             qra6 = true;
                            //         }
                            //         if(!audioClip1_9b) {
                            //             StartCoroutine(PlayAudioClipDelayed(audioClip1_9, 2f));
                            //             audioClip1_9b = true;
                            //         }

                            //         if(BlueYeastInBeaker2 == true) {
                            //             // empty yeast from bowl
                            //             // change liquid in beaker 2 to murky tan
                            //             AudioClip q7 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            //             if(!qra7) {
                            //                 StartCoroutine(PlayAudioClipDelayed(q7, .1f));
                            //                 qra7 = true;
                            //             }
                            //             if(!audioClip1_10b) {
                            //                 StartCoroutine(PlayAudioClipDelayed(audioClip1_10, 2f));
                            //                 audioClip1_10b = true;
                            //             }

                            //             if(BlueBeaker2InBeaker1 == true) {
                            //                 // play Blue reaction particle simulation
                            //                 if(!audioClip1_11b) {
                            //                     StartCoroutine(PlayAudioClipDelayed(audioClip1_11, 2f));
                            //                     audioClip1_11b = true;
                            //                 }
                            //             }
                            //         }
                            //     }
                            // }

                            // if(GreenDyeInBeaker1 == true) {
                            //     AudioClip q5 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            //     if(!qra5) {
                            //         StartCoroutine(PlayAudioClipDelayed(q5, .1f));
                            //         qra5 = true;
                            //     }
                            //     if(!audioClip1_8b) {
                            //         StartCoroutine(PlayAudioClipDelayed(audioClip1_8, 2f));
                            //         audioClip1_8b = true;
                            //     }
                                
                            //     if(GreenWaterCylInBeaker2 == true) {
                            //         // empty liquid from water cylinder
                            //         // fill up beaker with liquid
                            //         AudioClip q6 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            //         if(!qra6) {
                            //             StartCoroutine(PlayAudioClipDelayed(q6, .1f));
                            //             qra6 = true;
                            //         }
                            //         if(!audioClip1_9b) {
                            //             StartCoroutine(PlayAudioClipDelayed(audioClip1_9, 2f));
                            //             audioClip1_9b = true;
                            //         }

                            //         if(GreenYeastInBeaker2 == true) {
                            //             // empty yeast from bowl
                            //             // change liquid in beaker 2 to murky tan
                            //             AudioClip q7 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            //             if(!qra7) {
                            //                 StartCoroutine(PlayAudioClipDelayed(q7, .1f));
                            //                 qra7 = true;
                            //             }
                            //             if(!audioClip1_10b) {
                            //                 StartCoroutine(PlayAudioClipDelayed(audioClip1_10, 2f));
                            //                 audioClip1_10b = true;
                            //             }

                            //             if(GreenBeaker2InBeaker1 == true) {
                            //                 // play Green reaction particle simulation
                            //                 if(!audioClip1_11b) {
                            //                     StartCoroutine(PlayAudioClipDelayed(audioClip1_11, 2f));
                            //                     audioClip1_11b = true;
                            //                 }
                            //             }
                            //         }
                            //     }
                            // }

                            // if(YellowDyeInBeaker1 == true) {
                            //     AudioClip q5 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            //     if(!qra5) {
                            //         StartCoroutine(PlayAudioClipDelayed(q5, .1f));
                            //         qra5 = true;
                            //     }
                            //     if(!audioClip1_8b) {
                            //         StartCoroutine(PlayAudioClipDelayed(audioClip1_8, 2f));
                            //         audioClip1_8b = true;
                            //     }
                                
                            //     if(YellowWaterCylInBeaker2 == true) {
                            //         // empty liquid from water cylinder
                            //         // fill up beaker with liquid
                            //         AudioClip q6 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            //         if(!qra6) {
                            //             StartCoroutine(PlayAudioClipDelayed(q6, .1f));
                            //             qra6 = true;
                            //         }
                            //         if(!audioClip1_9b) {
                            //             StartCoroutine(PlayAudioClipDelayed(audioClip1_9, 2f));
                            //             audioClip1_9b = true;
                            //         }

                            //         if(YellowYeastInBeaker2 == true) {
                            //             // empty yeast from bowl
                            //             // change liquid in beaker 2 to murky tan
                            //             AudioClip q7 = audioClipQRAs[Random.Range(0, audioClipQRAs.Length)];
                            //             if(!qra7) {
                            //                 StartCoroutine(PlayAudioClipDelayed(q7, .1f));
                            //                 qra7 = true;
                            //             }
                            //             if(!audioClip1_10b) {
                            //                 StartCoroutine(PlayAudioClipDelayed(audioClip1_10, 2f));
                            //                 audioClip1_10b = true;
                            //             }

                            //             if(YellowBeaker2InBeaker1 == true) {
                            //                 // play Yellow reaction particle simulation
                            //                 if(!audioClip1_11b) {
                            //                     StartCoroutine(PlayAudioClipDelayed(audioClip1_11, 2f));
                            //                     audioClip1_11b = true;
                            //                 }
                            //             }
                            //         }
                            //     }
                            // }

                
                        }
                    }
                }
            }
        }
    }

    private IEnumerator ToggleGlowArea(float time) {
        yield return new WaitForSeconds(time);
        areaToggle.SetActive(true);
    }

    private IEnumerator HighlightObj(GameObject obj) {
        yield return new WaitForSeconds(5f);
        obj.GetComponent<Outline>().enabled = true;
    }

    void UnhighlightObj(GameObject obj) {
        obj.GetComponent<Outline>().enabled = false;
        StopCoroutine(HighlightObj(obj));
    }
}
