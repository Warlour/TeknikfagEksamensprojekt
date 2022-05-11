using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objects : MonoBehaviour {
    public GameObject[] signals;

    private void Start() {

        StartCoroutine(SignalSpin());
    }

    private IEnumerator SignalSpin() {
        for (; ; ) {
            foreach (var signal in signals) {
                signal.transform.RotateAround(signal.GetComponent<Collider>().bounds.center, Vector3.up, 1.0f);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
