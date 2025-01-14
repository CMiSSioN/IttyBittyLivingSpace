﻿

using System.Collections.Generic;

namespace IttyBittyLivingSpace {

    public class ModConfig {

        public const string SC_Upkeep = "IBLS_MechbayUpkeepModifier";
        public const string SC_Cargo = "IBLS_CargoStorageModifier";

        // If true, many logs will be printed
        public bool Debug = false;

        public float GearFactor = 1.0f;
        public int GearCostPerUnit = 100;
        public float GearExponent = 2.0f;

        public float PartsFactor = 1.0f;
        public int PartsCostPerTon = 10;
        public float PartsExponent = 2.0f;

        public Dictionary<string, float> PartsStorageTagMultis = new Dictionary<string, float>();

        public float UpkeepGearMulti = 0.02f;
        public float UpkeepChassisMulti = 0.010f;
        public Dictionary<string, float> UpkeepChassisTagMultis = new Dictionary<string, float>();

        public void LogConfig() {
            Mod.Log.Info("=== MOD CONFIG BEGIN ===");
            Mod.Log.Info($"  DEBUG: {this.Debug}");
            Mod.Log.Info($"  Storage: Gear       - Factor:x{GearFactor}  CostPerUnit:{GearCostPerUnit} Exponent:{GearExponent}");
            Mod.Log.Info($"  Storage: Mech Parts - Factor:x{PartsFactor} CostPerTon:{PartsCostPerTon} Exponent:{PartsExponent}");
            Mod.Log.Info($"  Upkeep: gearMulti: x{UpkeepGearMulti} chassisMulti: x{UpkeepChassisMulti}");
            Mod.Log.Info("=== MOD CONFIG END ===");
        }
        
    }
}
