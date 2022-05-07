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

    private void Start() {
        fadeRI = fade.GetComponent<RawImage>();
        fadeRI.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        StartCoroutine(FadeOn());

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

    public TextMeshProUGUI dayText;
    private int day;
    public GameObject fade;
    private RawImage fadeRI;

    public GameObject[] mgPrefabs;
    public GameObject[] mgObjects;

    public void NextDay() {
        Matches2 = 0;
        for (int i = 0; i < statusnames.Length; i++) {
            for (int j = 0; j < statusvars.Length; j++) {
                if (statusnames[i] != "Optimal" && statusvars[j].text == statusnames[i])
                    Matches2 += 1;
            }
        }
        if (Matches2 == 0) {
            fadeRI.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            StartCoroutine(FadeOn());

            day++;
            dayText.text = "Day " + day;

            for (int i = 0; i < statusvars.Length; i++) {
                rRange = Random.Range(0, 3);
                statusvars[i].text = statusnames[rRange];
                statusvars[i].color = Colors[rRange];
            }

            for (int i = 0; i < mgObjects.Length; i++) {
                Instantiate(mgPrefabs[i]);
                Destroy(mgObjects[i]);
            }
        }
    }

    private IEnumerator FadeOn() {
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

    public GameObject gameUI;
    public GameObject puzzleUI;
    public void Puzzle() {
        gameUI.SetActive(false);
        puzzleUI.SetActive(true);
    }

    public GameObject pressureUI;
    public void PressureFix(TextMeshProUGUI var) {
        if (var.text != "Optimal") {
            Puzzle();
            pressureUI.SetActive(true);
        }
    }

    public GameObject o2UI;
    public void O2Fix(TextMeshProUGUI var) {
        if (var.text != "Optimal") {
            Puzzle();
            o2UI.SetActive(true);
        }
    }

    public GameObject waterUI;
    public bool inWater;
    public void WaterFix(TextMeshProUGUI var) {
        if (var.text != "Optimal") {
            Puzzle();
            waterUI.SetActive(true);
            inWater = true;
        }
    }
}
