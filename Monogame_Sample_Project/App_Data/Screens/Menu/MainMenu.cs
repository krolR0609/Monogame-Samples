using Monogame_Sample_Project.App_Data.Controllers;
using Monogame_Sample_Project.Models.Graphics;
using Monogame_Sample_Project.Models.UI.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Sample_Project.App_Data.Screens.Menu
{
    public class MainMenu : BaseMenu
    {
        public MainMenu()
        {
            var items = new List<MenuItem>()
            {
                new MenuItem("Start", new GameScreen()),
                new MenuItem("Settings", new GameScreen()),
                new MenuItem("Exit", new GameScreen()),
            };

            menuController = new MenuController(items);
        }
    }
}
