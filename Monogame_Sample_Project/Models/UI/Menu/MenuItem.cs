using Monogame_Sample_Project.Models.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Sample_Project.Models.UI.Menu
{
    public class MenuItem
    {
        public string Name { get; protected set; }
        public GameScreen GameScreen { get; protected set; }

        public MenuItem(string name, GameScreen screen)
        {
            this.Name = name;
            this.GameScreen = screen;
        }
    }
}
