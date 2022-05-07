using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusButtons : MonoBehaviour {
    public GameObject hsObject;
    public TextMeshProUGUI hsText;
    public GameObject ecPanel;
    public TextMeshProUGUI[] statusvars;
    private bool expanded;

    // 0 = Critical, 1 = Below optimal, 2 = Optimal, 3 = Above optimal
    // 0 = Red, 1 = Light Red, 2 = Green, 3 = Blue
    public string[] statusnames;
    public Color32[] Colors;

    public GameObject indicator;
    public GameObject indicatordot;
    private int Matches;
    private int Matches2;
    private int rRange;

    public GameObject domehole;

    public TextMeshProUGUI dayText;
    private int day;
    public GameObject fadeObject;

    public GameObject gameUI;
    public GameObject puzzleUI;

    public GameObject pressureUI;

    public GameObject o2UI;

    public GameObject waterUI;
    public bool inWater;

    private void Start() {
        fadeObject.GetComponent<RawImage>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        StartCoroutine(FadeOn(fadeObject));

        expanded = false;
        ecPanel.SetActive(false);

        for (int i = 0; i < statusvars.Length; i++) {
            rRange = Random.Range(0, 3);
            statusvars[i].text = statusnames[rRange];
            statusvars[i].color = Colors[rRange];
        }

        StartCoroutine(IndicatorFlash());

        day = 1;
        dayText.text = "Day " + day;
    }

    private void Update() {
        // if Pressure not optimal
        if (statusvars[0].text != "Optimal") {
            domehole.SetActive(true);
        } else {
            domehole.SetActive(false);
        }
    }

    public void Expandcontract() {
        if (expanded == false) {
            hsText.text = "‹";
            ecPanel.SetActive(true);
            indicatordot.SetActive(false);
        } else {
            hsText.text = "›";
            ecPanel.SetActive(false);
            indicator.SetActive(false);
        }
        expanded = !expanded;
    }

    public void NextDay() {
        Matches2 = 0;
        for (int i = 0; i < statusnames.Length; i++) {
            for (int j = 0; j < statusvars.Length; j++) {
                if (statusnames[i] != "Optimal" && statusvars[j].text == statusnames[i])
                    Matches2 += 1;
            }
        }
        if (Matches2 == 0) {
            fadeObject.GetComponent<RawImage>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            StartCoroutine(FadeOn(fadeObject));

            day++;
            dayText.text = "Day " + day;

            for (int i = 0; i < statusvars.Length; i++) {
                rRange = Random.Range(0, 3);
                statusvars[i].text = statusnames[rRange];
                statusvars[i].color = Colors[rRange];
            }

        }
    }

    public IEnumerator FadeOn(GameObject fade) {
        RawImage fadeRI = fade.GetComponent<RawImage>();
        while (fadeRI.color.a > 0.0f) {
            fade.SetActive(true);
            fadeRI.color = new Color(
                fadeRI.color.r,
                fadeRI.color.g,
                fadeRI.color.b,
                fadeRI.color.a - 0.01f
            );
            yield return new WaitForSeconds(0.01f);
        }
        fade.SetActive(false);
    }

    public IEnumerator FadeOff(GameObject fade) {
        if (fade == null) {
            fade = fadeObject;
        }
        RawImage fadeRI = fade.GetComponent<RawImage>();
        fadeRI.color = new Color(
            fadeRI.color.r,
            fadeRI.color.g,
            fadeRI.color.b,
            0.0f
        );
        while (fadeRI.color.a < 1.0f) {
            fade.SetActive(true);
            fadeRI.color = new Color(
                fadeRI.color.r,
                fadeRI.color.g,
                fadeRI.color.b,
                fadeRI.color.a + 0.01f
            );
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator IndicatorFlash() {
        for (; ; ) {
            Matches = 0;
            for (int i = 0; i < statusnames.Length; i++) {
                for (int j = 0; j < statusvars.Length; j++) {
                    if (statusnames[i] != "Optimal" && statusvars[j].text == statusnames[i])
                        Matches += 1;
                }
            }
            if (Matches > 0) {
                if (expanded) {
                    indicatordot.SetActive(false);
                    indicator.SetActive(!indicator.activeSelf);
                } else {
                    indicator.SetActive(false);
                    indicatordot.SetActive(!indicatordot.activeSelf);
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void Puzzle() {
        gameUI.SetActive(false);
        puzzleUI.SetActive(true);
    }

    public void PressureFix(TextMeshProUGUI var) {
        if (var.text != "Optimal") {
            Puzzle();
            pressureUI.SetActive(true);
        }
    }

    public void O2Fix(TextMeshProUGUI var) {
        if (var.text != "Optimal") {
            Puzzle();
            o2UI.SetActive(true);
        }
    }

    public void WaterFix(TextMeshProUGUI var) {
        if (var.text != "Optimal") {
            Puzzle();
            waterUI.SetActive(true);
            inWater = true;
        }
    }
}
