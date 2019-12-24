

using StardewModdingAPI;
using StardewValley;
using System;

using Steamworks;

namespace ShipmentTrackerSMAPI {

    public class MainModClass : Mod {
        private static MainModClass instance;

        public override void Entry(IModHelper helper) {
           instance = this;
            helper.Events.GameLoop.SaveLoaded += OnLoad;

            Log("RetroActive Achievement Loader by Iceburg333 => Initialized");
        }

        private void OnLoad(object sender, EventArgs e) {            
            Game1.stats.checkForAchievements();
            Log("Player has " + Game1.player.achievements.Count + " achievements");
            Log("Game has " + Game1.achievements.Count + " achievements");
            Log("Steam API is running? " + SteamAPI.IsSteamRunning());

            foreach (int achievement in Game1.player.achievements)
            {
                string achievementName = Game1.achievements[achievement];
                Log("Player has achievement " + achievement + ": " + achievementName);
                //Program.sdk.GetAchievement(string.Concat((object)achievement));
            }

            if (SteamAPI.IsSteamRunning()) { 
                Game1.playSound("achievement");
            }
        }

        private void CheckForSteamAchievements() {
            CheckSkillAchievements();
        }

        private void CheckSkillAchievements() {
            int level10s = 0;
            if (10 == Game1.player.farmingLevel.Value)
            {
                level10s++;
            }
            if (10 == Game1.player.miningLevel.Value)
            {
                level10s++;
            }
            if (10 == Game1.player.fishingLevel.Value)
            {
                level10s++;
            }
            if (10 == Game1.player.foragingLevel.Value)
            {
                level10s++;
            }
            if (10 == Game1.player.combatLevel.Value)
            {
                level10s++;
            }

            if (level10s >= 1)
            {
                Game1.getSteamAchievement("Achievement_SingularTalent");
            }

            if (level10s >= 5)
            {
                Game1.getSteamAchievement("Achievement_MasterOfTheFiveWays");
            }

        }

        public static void Log(string message) {
            instance.Monitor.Log(message, LogLevel.Debug);
        }

        
    }
}
