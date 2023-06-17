using HarmonyLib;
using NCMS;
using UnityEngine;

namespace MoreNativeSpeed{
    [ModEntry]
    class Main : MonoBehaviour{
        void Awake(){
            Harmony.CreateAndPatchAll(typeof(SpeedModifier));
            MapBox.instance.selectedButtons.clockButton.sizeButtons.transform.GetChild(5).GetComponent<PowerButton>().init();
        }
    }
}