

using StardewModdingAPI;
using StardewValley;
using StardewValley.Network;
using Microsoft.Xna.Framework.Net;
using System;
using System.Collections.Generic;
using System.IO;
using StardewValley.Menus;

namespace ShipmentTrackerSMAPI {

    public class MainModClass : Mod {
        private static MainModClass instance;

      private String statsFilePath;
        private int lastDayRun = -1;
        private List<Item> itemsToShip;


        public override void Entry(IModHelper helper) {
           instance = this;
            statsFilePath = helper.DirectoryPath + Path.DirectorySeparatorChar;
            helper.Events.GameLoop.Saved += AfterSaveEvent;
            helper.Events.GameLoop.OneSecondUpdateTicking += GameEvents_OneSecondTick;

            //also maybe could use:
            //GameEvents.Events.TimeEvents.DayOfMonthChanged

            Log("RetroActive Achievement Loader by Iceburg333 => Initialized");
        }

        private void AfterSaveEvent(object sender, EventArgs e) {            
            Log("after save");
        }

        private void GameEvents_OneSecondTick(object sender, EventArgs e) {
            if (!Game1.hasLoadedGame) { 
                return;
            }
            Log("On Second Tick");
          
        }
    
        public static void Log(string message) {
            instance.Monitor.Log(message, LogLevel.Debug);
        }
    }
}
