using Monogame_Sample_Project.Models.UI.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Sample_Project.App_Data.Controllers
{
    public class MenuController
    {
        public int CurrentMenuItem {
            get; private set; }
        public List<MenuItem> MenuItems {
            get; }

        public int MaxWordLenght {
            get
            {
                return MenuItems.Max(c => c.Name.Length);
            }
        }

        public MenuController(List<MenuItem> items)
        {
            if(items == null)
            {
                this.MenuItems = new List<MenuItem>();
            }
            this.MenuItems = items;
            this.CurrentMenuItem = 0;
        }

        public void Up()
        {
            CurrentMenuItem--;
            if (CurrentMenuItem < 0) CurrentMenuItem = MenuItems.Count - 1;
        }

        public void Down()
        {
            CurrentMenuItem++;
            if (CurrentMenuItem > MenuItems.Count - 1) CurrentMenuItem = 0;
        }

        public void Select()
        {
            ScreenManager.Instance.LoadGameScreen(MenuItems[CurrentMenuItem].GameScreen);
        }
    }
}
