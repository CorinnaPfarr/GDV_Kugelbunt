using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningTextScript : MonoBehaviour {

    private TextMeshProUGUI textMesh;

    public GameObject Player;
    private float maxBlinkCount = 5;
    private float waitTimeBetweenBlinks = 0.25f;
    private CanvasRenderer canRenderer;

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
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);
            StartCoroutine(Blink(maxBlinkCount));
        }
    }

    private IEnumerator Blink(float maxBlinkCount)
    {
        int blinkCount = 0;

        while (blinkCount < maxBlinkCount)
        {
            yield return new WaitForSeconds(waitTimeBetweenBlinks);
            gameObject.SetActive(false);
            yield return new WaitForSeconds(waitTimeBetweenBlinks);
            gameObject.SetActive(true);
            blinkCount++;
            yield return null;
        }
    }
   


}
