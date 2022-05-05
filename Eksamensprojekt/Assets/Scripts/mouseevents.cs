using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace Warlour.MouseInteraction {
    public class mouseevents : MonoBehaviour {

        public StatusButtons statusscript;

        public GameObject holetext;
        public GameObject holeobject;
        public GameObject glowobject;

        // pressurevar = 0, o2var = 1, watervar = 2

        public void HoleFix() {
            holetext.SetActive(true);
            holeobject.SetActive(false);
            glowobject.SetActive(false);
            statusscript.statusvars[0].SetText(statusscript.statusnames[2]);
            statusscript.statusvars[0].color = statusscript.Colors[2];
            StartCoroutine(FixDone());
        }

        int o2fixes = 0;
        bool activated = false;
        public RectTransform wheel;

        public void O2Fix() {
            if (activated == false) {
                StartCoroutine(RotateWheel());
                o2fixes += 1;
            }
            activated = true;
        }

        private IEnumerator RotateWheel() {
            while (wheel.localRotation.z < 1) {
                wheel.Rotate(new Vector3(0,0,1), -10);
                Debug.Log(wheel.localRotation.z);
                yield return new WaitForSeconds(0.01f);
            }
        }

        public GameObject[] plants;
        public GameObject completepanel;

        public void PlantFix(GameObject salad) {
            salad.SetActive(false);
            o2fixes += 1;
        }

        public GameObject puzzleUI;
        public GameObject gameUI;
        public GameObject[] puzzleUIs;

        private IEnumerator FixDone() {
            yield return new WaitForSeconds(3f);
            for (int i = 0; i < puzzleUIs.Length; i++) {
                puzzleUIs[i].SetActive(false);
            }
            puzzleUI.SetActive(false);
            gameUI.SetActive(true);

        }

        public GameObject cpanel;

        private void Update() {
            if (o2fixes >= 4) {
                cpanel.SetActive(true);
                statusscript.statusvars[1].SetText(statusscript.statusnames[2]);
                statusscript.statusvars[1].color = statusscript.Colors[2];
                StartCoroutine(FixDone());
            }
        }
    }
}