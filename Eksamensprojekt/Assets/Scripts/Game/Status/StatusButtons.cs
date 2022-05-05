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
    public string[] statusnames;
    public Color32[] Colors;

    public GameObject indicator;
    public GameObject indicatordot;
    private int Matches;

    private void Start (){
        expanded = false;
        ecPanel.SetActive(false);

        for (int i = 0; i < statusvars.Length; i++) {
            statusvars[i].text = statusnames[1];
            statusvars[i].color = Colors[1];
        }

        Matches = 0;
        StartCoroutine(indicatorflash());
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
        
    }

    private IEnumerator indicatorflash() {
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

    public void WaterFix(TextMeshProUGUI var) {
        if (var.text != "Optimal") {
            Puzzle();
            waterUI.SetActive(true);
        }
        // statusvars[2].SetText(statusnames[2]);
        // statusvars[2].color = Colors[2];

    }
}
