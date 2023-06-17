using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using static Config;
using ModDeclaration;
using UnityEngine.EventSystems;

namespace MoreNativeSpeed { 
    public static class SpeedModifier {
    public static Image CurrentSpeedIcon = null;

    public static Sprite iconClockX10 = Mod.EmbededResources.LoadSprite("MoreNativeSpeed.Resources.iconClockX10.png");
    public static Sprite iconClockX15 = Mod.EmbededResources.LoadSprite("MoreNativeSpeed.Resources.iconClockX15.png");
    public static Sprite iconClockX20 = Mod.EmbededResources.LoadSprite("MoreNativeSpeed.Resources.iconClockX20.png");
    public static Sprite iconClockX30 = Mod.EmbededResources.LoadSprite("MoreNativeSpeed.Resources.iconClockX30.png");
    public static Sprite iconClockX50 = Mod.EmbededResources.LoadSprite("MoreNativeSpeed.Resources.iconClockX50.png");
    public static Sprite iconClockX100 = Mod.EmbededResources.LoadSprite("MoreNativeSpeed.Resources.iconClockX100.png");
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(PowerButton), "init")]
    public static void postInit(ref PowerButton __instance)
    {
        if (__instance.type == PowerButtonType.TimeScale && int.Parse(__instance.transform.name) == 5)
        {
            time_scales = new Dictionary<int, float>
            {
                { 0, 0.5f },
                { 1, 1f },
                { 2, 2f },
                { 3, 3f },
                { 4, 4f },
                { 5, 5f },
                { 6, 10f },
                { 7, 15f },
                { 8, 20f },
                { 9, 30f },
                { 10, 50f },
                { 11, 100f },
                { 40, 40f }
            };
            time_scales_list = new List<float>
            {
                0.5f,
                1f,
                2f,
                3f,
                4f,
                5f,
                10f,
                15f,
                20f,
                30f,
                50f,
                100f,
                40f
            };

            Vector3 space = __instance.transform.localPosition - MapBox.instance.selectedButtons.clockButton
                .sizeButtons.transform.GetChild(4).transform.localPosition;
            GameObject newObj_6 = GameObject.Instantiate(__instance.gameObject, __instance.transform.parent);
            newObj_6.name = "6";
            newObj_6.transform.localPosition = __instance.transform.localPosition + space;
            newObj_6.transform.GetChild(0).GetComponent<Text>().text = "x10";
            newObj_6.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = iconClockX10;

            GameObject newObj_7 = GameObject.Instantiate(__instance.gameObject, __instance.transform.parent);
            newObj_7.name = "7";
            newObj_7.transform.localPosition = __instance.transform.localPosition + space * 2;
            newObj_7.transform.GetChild(0).GetComponent<Text>().text = "x15";
            newObj_7.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = iconClockX15;
            GameObject newObj_8 = GameObject.Instantiate(__instance.gameObject, __instance.transform.parent);
            newObj_8.name = "8";
            newObj_8.transform.localPosition = __instance.transform.localPosition + space * 3;
            newObj_8.transform.GetChild(0).GetComponent<Text>().text = "x20";
            newObj_8.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = iconClockX20;
            GameObject newObj_9 = GameObject.Instantiate(__instance.gameObject, __instance.transform.parent);
            newObj_9.name = "9";
            newObj_9.transform.localPosition = __instance.transform.localPosition + space * 4;
            newObj_9.transform.GetChild(0).GetComponent<Text>().text = "x30";
            newObj_9.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = iconClockX30;
            GameObject newObj_10 = GameObject.Instantiate(__instance.gameObject, __instance.transform.parent);
            newObj_10.name = "10";
            newObj_10.transform.localPosition = __instance.transform.localPosition + space * 5;
            newObj_10.transform.GetChild(0).GetComponent<Text>().text = "x50";
            newObj_10.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = iconClockX50;
            GameObject newObj_11 = GameObject.Instantiate(__instance.gameObject, __instance.transform.parent);
            newObj_11.name = "11";
            newObj_11.transform.localPosition = __instance.transform.localPosition + space * 6;
            newObj_11.transform.GetChild(0).GetComponent<Text>().text = "x100";
            newObj_11.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = iconClockX100;
        }
    }
    [HarmonyPostfix]
    [HarmonyPatch(typeof(PowerClockButton), "Update")]
    public static void postUpdate(ref PowerClockButton __instance)
    {
        if (CurrentSpeedIcon == null)
            CurrentSpeedIcon = __instance.currentSpeedIcon;
        var clockIcon = PowerButton.get("clock").transform.GetChild(3).GetComponent<Image>();
        float latestUsed = Config.timeScale;
        if ((double) latestUsed != 10.0)
        {
            if ((double) latestUsed != 15.0)
            {
                if ((double) latestUsed != 20.0)
                {
                    if ((double) latestUsed != 30.0)
                    {
                        if ((double) latestUsed != 50.0)
                        {
                            if ((double) latestUsed != 100.0)
                                return;
                            CurrentSpeedIcon.sprite = iconClockX100;
                            clockIcon.sprite = iconClockX100;
                        }
                        else
                        {
                            CurrentSpeedIcon.sprite = iconClockX50;
                            clockIcon.sprite = iconClockX50;
                        }
                    }
                    else
                    {
                        CurrentSpeedIcon.sprite = iconClockX30;
                        clockIcon.sprite = iconClockX30;
                    }

                }
                else
                {
                    CurrentSpeedIcon.sprite = iconClockX20;
                    clockIcon.sprite = iconClockX20;
                }
            }
            else
            {
                CurrentSpeedIcon.sprite = iconClockX15;
                clockIcon.sprite = iconClockX15;
            }
        }
        else
        {
            CurrentSpeedIcon.sprite = iconClockX10;
            clockIcon.sprite = iconClockX10;
        } 
    }
    }
}
