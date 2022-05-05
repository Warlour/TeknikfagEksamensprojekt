using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace Warlour.MouseInteraction {
    public class mouseevents : MonoBehaviour{

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
    }
}