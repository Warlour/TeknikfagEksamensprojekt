using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusButtons : MonoBehaviour{
    public GameObject hsObject;
    public TextMeshProUGUI hsText;
    public GameObject ecPanel;
    public TextMeshProUGUI[] statusvars;
    private bool expanded;
    private void Start (){
        expanded = false;
        ecPanel.SetActive(false);

        for (int i = 0; i < statusvars.Length; i++) {
            statusvars[i].text = "Below Optimal";
            statusvars[i].color = new Color32(255, 135, 135, 255);
        }

    }
    
    public void Expandcontract() {
        if (expanded == false) {
            hsText.text = "‹";
            ecPanel.SetActive(true);

        } else {
            hsText.text = "›";
            ecPanel.SetActive(false);
        }
        expanded = !expanded;
    }
    public void NextDay() {
        
    }
}
