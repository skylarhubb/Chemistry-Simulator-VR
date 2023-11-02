using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConclusionHover : MonoBehaviour
{
    public float amplitude = .5f;
    public float speed = 1f;

    public float duration = 20.0f; 
    public float height = 20.0f;

    public Vector3 startPos;

    public GameObject Girlie;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        StartCoroutine(FloatUp(10f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + amplitude * Vector3.up * Mathf.Sin(speed * Time.time);
    }

    public IEnumerator FloatUp(float delay) {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0.0f;
        Vector3 startingPosition = transform.position;
        Vector3 targetPosition = startingPosition + new Vector3(0, height, 0);

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        Girlie.SetActive(false);
    }
}
