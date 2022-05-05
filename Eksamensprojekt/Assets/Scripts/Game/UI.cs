using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour{

    public Image recsprite;
    public Sprite[] sprites;

    private void Start() {
        StartCoroutine("UIchange");
        StartCoroutine("holeflicker");
    }

    private IEnumerator UIchange() {
        for (; ; ) {
            flickersprite();
            yield return new WaitForSeconds(1f);
        }
    }

    public GameObject holeobject;
    public GameObject glowobject;

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
