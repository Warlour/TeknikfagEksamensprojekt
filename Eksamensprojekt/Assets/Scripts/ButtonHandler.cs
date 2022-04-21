using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour{
    public Camera[] cameras;

    public void ChangeCamera(int button){
        for (int i = 0; i < cameras.Length; i++){
            if (button != i)
                cameras[i].enabled = false;
            else
                cameras[i].enabled = true;
        }
    }
}