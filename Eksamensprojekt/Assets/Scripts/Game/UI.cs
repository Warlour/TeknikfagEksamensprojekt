using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour{

    public Image recsprite;
    public Sprite[] sprites;

    public GameObject holeobject;
    public GameObject glowobject;

    public float timer;
    public TextMeshProUGUI timertext;
    public TextMeshProUGUI exTimertext;

    public StatusButtons statusscript;

    private void Start() {
        exTimertext.color = new Color(exTimertext.color.r, exTimertext.color.g, exTimertext.color.b, 0.0f);

        StartCoroutine(UIchange());
        StartCoroutine(holeflicker());
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown() {
        while (true) {
            yield return new WaitForSeconds(1.0f);
            if (timer > 0) {
                timer--;
                timertext.text = timer + " seconds";
            } else {
                StartCoroutine(lose());
                break;
            }
        }
    }

    public GameObject loseText;

    private IEnumerator lose() {
        StartCoroutine(statusscript.FadeOff(null));
        yield return new WaitForSeconds(1.0f);
        loseText.SetActive(true);

        yield return new WaitForSeconds(3.0f);
        loseText.SetActive(false);
        statusscript.fadeObject.SetActive(false);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public IEnumerator FadeExText() {
        yield return new WaitForSeconds(0.5f);
        while (exTimertext.color.a > 0.0f) {
            exTimertext.color = new Color(
                exTimertext.color.r,
                exTimertext.color.g,
                exTimertext.color.b,
                exTimertext.color.a - 0.01f
            );
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator UIchange() {
        for (; ; ) {
            flickersprite();
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator holeflicker() {
        for (; ; ) {
            if (holeobject.activeSelf == true) {
                glowobject.SetActive(!glowobject.activeSelf);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void flickersprite() {
        if (recsprite.sprite == sprites[0])
            recsprite.sprite = sprites[1];
        else
            recsprite.sprite = sprites[0];
    }
}
