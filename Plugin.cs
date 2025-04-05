using System;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace com.shroudednight.MailOrderMayhem;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    public override void Load()
    {
        // Plugin startup logic
        try
        {
            var harmony = new Harmony($"{MyPluginInfo.PLUGIN_GUID}");
            harmony.PatchAll();
        }
        catch (Exception e)
        {
            Log.FATAL($"Unable to load ${MyPluginInfo.PLUGIN_GUID}: {e}");
            throw;
        }
        Log.INFO($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded");
    }

    [HarmonyPatch(typeof(FurnishingsController), nameof(FurnishingsController.UpdateListDisplay))]
    public class FurnishingsController_UpdateListDisplay
    {
        public static bool Prefix(FurnishingsController __instance)
        {
            foreach (var preset in Toolbox.Instance.allFurniture)
            {
                preset.purchasable = true;
            }
            return true;
        }
    }
    
    [HarmonyPatch(typeof(ApartmentItemsController), nameof(ApartmentItemsController.UpdateListDisplay))]
    public class ApartmentItemsController_UpdateListDisplay
    {
        public static bool Prefix(ApartmentItemsController __instance)
        {
            foreach (var preset in Toolbox.Instance.objectPresetDictionary)
            {
                preset.Value.spawnable = true;
                preset.Value.allowInApartmentShop = true;
            }

            return true;
        }
    }
}