﻿using Harmony;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Reflection;

namespace IttyBittyLivingSpace {

    public static class Mod {
        public static Logger Log;
        public static string ModDir;
        public static ModConfig Config;
    }

    public static class IttyBittyLivingSpace {

        public const string HarmonyPackage = "us.frostraptor.IttyBittyLivingSpace";
        public const string LogName = "itty_bitty_living_space";

        public static readonly Random Random = new Random();

        public static void Init(string modDirectory, string settingsJSON) {
            Mod.ModDir = modDirectory;

            Exception settingsE = null;
            try {
                Mod.Config = JsonConvert.DeserializeObject<ModConfig>(settingsJSON);
            } catch (Exception e) {
                settingsE = e;
                Mod.Config = new ModConfig();
            }

            Mod.Log = new Logger(modDirectory, LogName);

            Assembly asm = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
            Mod.Log.Info($"Assembly version: {fvi.ProductVersion}");

            Mod.Log.Debug($"ModDir is:{modDirectory}");
            Mod.Log.Debug($"mod.json settings are:({settingsJSON})");
            Mod.Config.LogConfig();

            if (settingsE != null) {
                Mod.Log.Info($"ERROR reading settings file! Error was: {settingsE}");
            } else {
                Mod.Log.Info($"INFO: No errors reading settings file.");
            }

            // Initialize custom components
            CustomComponents.Registry.RegisterSimpleCustomComponents(Assembly.GetExecutingAssembly());

            // Initialize harmony patches
            var harmony = HarmonyInstance.Create(HarmonyPackage);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

    }
}
