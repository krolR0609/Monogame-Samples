using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Sample_Project.App_Data
{
    public class GameSettings
    {
        public GameSettings()
        {
            SCREENS_NAMESPACE = "Monogame_Sample_Project.App_Data.Screens.";
        }

        public readonly string SCREENS_NAMESPACE;

        private static GameSettings settings;
        public static GameSettings Instance
        {
            get
            {
                if(settings == null)
                {
                    settings = new GameSettings();
                }
                return settings;
            }
        }
    }
}
