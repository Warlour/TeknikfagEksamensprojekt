using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour{

    public Image recsprite;
    public Sprite[] sprites;

    private void Start() {
        StartCoroutine("UIchange");
    }

    private IEnumerator UIchange() {
        for (; ; ) {
            flickersprite();
            yield return new WaitForSeconds(1f);
        }
    }

    private void flickersprite() {
        if (recsprite.sprite == sprites[0])
            recsprite.sprite = sprites[1];
        else
            recsprite.sprite = sprites[0];
    }
}
