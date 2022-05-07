using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace Warlour.MouseInteraction {
    public class mouseevents : MonoBehaviour {

        public StatusButtons statusscript;

        public GameObject holecomplete;
        public GameObject holeobject;
        public GameObject glowobject;

        int o2fixes;
        bool activated;
        public RectTransform wheel;

        public GameObject[] plants;
        public GameObject completepanel;

        public RectTransform hoseRT;
        private bool startDrag;

        public GameObject puzzleUI;
        public GameObject gameUI;
        public GameObject[] puzzleUIs;

        public GameObject o2cpanel;
        public GameObject watercpanel;

        private void Start() {
            activated = false;
            o2fixes = 0;
        }

        public void HoleFix() {
            holecomplete.SetActive(true);
            holeobject.SetActive(false);
            glowobject.SetActive(false);
            statusscript.statusvars[0].SetText(statusscript.statusnames[2]);
            statusscript.statusvars[0].color = statusscript.Colors[2];
            StartCoroutine(FixDone());
            StartCoroutine(ResetMiniGames("pressure"));
        }

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
                yield return new WaitForSeconds(0.01f);
            }
        }

        public void PlantFix(GameObject salad) {
            salad.SetActive(false);
            o2fixes += 1;
        }

        public void StartDragUI() {
            startDrag = true;
        }
        public void StopDragUI() {
            startDrag = false;
        }

        private IEnumerator FixDone() {
            yield return new WaitForSeconds(3.0f);
            for (int i = 0; i < puzzleUIs.Length; i++) {
                puzzleUIs[i].SetActive(false);
            }

            puzzleUI.SetActive(false);
            gameUI.SetActive(true);
        }

        private IEnumerator ResetMiniGames(string game) {
            yield return new WaitForSeconds(3.0f);
            if (game == "pressure") {
                holecomplete.SetActive(false);
                holeobject.SetActive(true);
                glowobject.SetActive(true);
            } else if (game == "o2") {
                o2cpanel.SetActive(false);
                for (int i = 0; i < plants.Length; i++) {
                    plants[i].SetActive(true);
                }
            } else if (game == "water") {
                hoseRT.sizeDelta = new Vector3(130.0f, 45.0f);
                watercpanel.SetActive(false);
            }
        }

        private void Update() {
            if (o2fixes >= 4) {
                o2cpanel.SetActive(true);
                statusscript.statusvars[1].SetText(statusscript.statusnames[2]);
                statusscript.statusvars[1].color = statusscript.Colors[2];
                o2fixes = 0;
                wheel.localRotation = new Quaternion(0, 0, 0, 0);
                StartCoroutine(FixDone());
                StartCoroutine(ResetMiniGames("o2"));
            }

            if (statusscript.inWater == true) {
                if (startDrag) {
                    if (hoseRT.sizeDelta.x < 900)
                        hoseRT.sizeDelta = new Vector3(-Input.mousePosition.x + 1425.0f, 45.0f);
                }
                if (hoseRT.sizeDelta.x >= 900) {
                    watercpanel.SetActive(true);
                    statusscript.statusvars[2].SetText(statusscript.statusnames[2]);
                    statusscript.statusvars[2].color = statusscript.Colors[2];
                    statusscript.inWater = false;
                    StartCoroutine(FixDone());
                    StartCoroutine(ResetMiniGames("water"));
                }
            }
        }
    }
}