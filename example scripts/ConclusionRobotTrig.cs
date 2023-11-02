using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConclusionRobotTrig : MonoBehaviour
{
    public Texture2D normalTexture;
    public Texture2D creepyHappyTexture;
    public Texture2D angryTexture;
    private Renderer renderer; 
    private Texture2D originalTexture;

    public float duration = 60.0f;
    public TextMeshProUGUI creditsText;

    void Start()
    {
        renderer = GetComponent<Renderer>(); 
        GetComponent<Renderer>().material.mainTexture = normalTexture;
        StartCoroutine(Creepy(1f));
        StartCoroutine(Angry(6.5f));
        StartCoroutine(RollCredits(15f));
    }

    public IEnumerator Creepy(float delay) {       
        yield return new WaitForSeconds(delay);
        GetComponent<Renderer>().material.mainTexture = creepyHappyTexture;
    }

    public IEnumerator Angry(float delay) {       
        yield return new WaitForSeconds(delay);
        GetComponent<Renderer>().material.mainTexture = angryTexture;
    }

    public IEnumerator RollCredits(float delay) {
        yield return new WaitForSeconds(delay);
        
        float elapsedTime = 0.0f;

        creditsText.enabled = true;

        while (elapsedTime < duration)
        {
            creditsText.rectTransform.position += new Vector3(0, 10.0f, 0) * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        creditsText.enabled = false;
    }

    



}
