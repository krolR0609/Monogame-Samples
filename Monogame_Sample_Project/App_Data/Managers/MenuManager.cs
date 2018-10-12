using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Monogame_Sample_Project.Models.Graphics;
using Monogame_Sample_Project.Models.Graphics.Menu;

namespace Monogame_Sample_Project.App_Data.Managers
{
    public class MenuManager
    {
        private Menu menu;

        public MenuManager()
        {
            menu = new Menu();
            menu.OnMenuChange += Menu_OnMenuChange;
        }

        private void Menu_OnMenuChange(object sender, EventArgs e)
        {
            XmlManager<Menu> xmlManager = new XmlManager<Menu>();
            menu.UnloadContent();
            //Transition
            menu = xmlManager.Load(menu.ID);
            menu.LoadContent();
        }

        public void LoadContent(string menuPath)
        { 
            if(menuPath != String.Empty)
            {
                menu.ID = menuPath;
            }
        }

        public void UnloadContent()
        {
            menu.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            menu.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);
        }
    }
}
