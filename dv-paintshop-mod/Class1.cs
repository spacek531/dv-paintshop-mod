using System;
using System.Reflection;
using System.Collections.Generic;
using Harmony12;
using UnityModManagerNet;
using UnityEngine;
using SkinManagerMod;

namespace dv_paintshop_mod
{
    public class Main
    {
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = HarmonyInstance.Create(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            //SkinManagerMod.Main.lastSteamerSkin = null;
            return true;
        }
    }

    [HarmonyPatch(typeof(LocoSimulation), "Awake")]
    class LocoSimulation_Awake_Patch
    {
        static void Postfix(LocoSimulation __instance)
        {
            TrainCar myTrainCar = __instance.GetComponent<TrainCar>();
            if (myTrainCar != null)
            {
                Debug.LogError("Found train car in LocoSimulation.Awake!");
            }
            else
            {
                Debug.LogError("DID NOT find train car in LocoSimulation.Awake!");
            }
        }
    }

}
