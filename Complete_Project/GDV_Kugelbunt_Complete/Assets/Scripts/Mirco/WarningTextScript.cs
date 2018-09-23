using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningTextScript : MonoBehaviour {

    private TextMeshProUGUI textMesh;

    public GameObject Player;
    private float maxBlinkCount = 5;
    private float waitTimeBetweenBlinks = 0.5f;

    private Coroutine blinkCoroutine;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {
        textBlink();

    }

    public void textBlink()
    {
        if (Player.transform.position.z < 10)
        {
            textMesh.enabled = false;
        }
        else {
            textMesh.enabled = true;
            if(blinkCoroutine == null)
                blinkCoroutine = StartCoroutine(Blink(maxBlinkCount));
        }
    }

    private IEnumerator Blink(float maxBlinkCount)
    {
        int blinkCount = 0;

        while (blinkCount < maxBlinkCount)
        {
            yield return new WaitForSeconds(waitTimeBetweenBlinks);
            textMesh.text = "";
            yield return new WaitForSeconds(waitTimeBetweenBlinks);
            textMesh.text = "Warning!!!";
            blinkCount++;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
