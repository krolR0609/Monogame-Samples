using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    public abstract class BaseMenu : GameScreen
    {
        protected MenuController menuController;

        private Vector2 position;
        private SpriteFont menuFont;
        private KeyboardState previousState;

        public BaseMenu()
        {
            menuController = new MenuController(null);
            position = new Vector2 (ScreenManager.Instance.Dimensions.X / 2,
                                    ScreenManager.Instance.Dimensions.Y / 2.5f);
        }

        public override void LoadContent()
        {
            base.LoadContent();
            menuFont = content.Load<SpriteFont>("Fonts/Font");
        }

        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up) && !previousState.IsKeyDown(Keys.Up))
            {
                menuController.Up();
            }
            if (kstate.IsKeyDown(Keys.Down) && !previousState.IsKeyDown(Keys.Down))
            {
                menuController.Down();
            }
            if (kstate.IsKeyDown(Keys.Enter) && !previousState.IsKeyDown(Keys.Enter))
            {
                menuController.Select();
            }

            previousState = kstate;
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int maxLength = menuController.MaxWordLenght;

            for(int i = 0; i < menuController.MenuItems.Count; i++)
            {
                if(i == menuController.CurrentMenuItem)
                {
                    spriteBatch.DrawString(
                    menuFont,
                    menuController.MenuItems[i].Name,
                        new Vector2(position.X - (maxLength * 3),
                                    position.Y + (i * menuFont.LineSpacing)),
                    Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(
                    menuFont,
                    menuController.MenuItems[i].Name,
                        new Vector2(position.X - (maxLength * 3),
                                    position.Y + (i * menuFont.LineSpacing)),
                    Color.White);
                }
            }
        }
    }
}
