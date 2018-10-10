using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Monogame_Sample_Project.App_Data.Screens.LoadScreens.GameLoad;
using Monogame_Sample_Project.Models.Graphics;

namespace Monogame_Sample_Project.App_Data
{
    public class ScreenManager
    {
        private GameScreen currentScreen;

        public ScreenManager()
        {
            Dimensions = new Vector2(640, 480);
            currentScreen = new SplashScreen();

            IsFullScreen = false;
        }

        public void LoadGameScreen(GameScreen gameScreen)
        {
            currentScreen.UnloadContent();
            currentScreen = gameScreen;
            currentScreen.LoadContent();
        }

        public Vector2 Dimensions { get; private set; }
        public ContentManager Content { get; private set; }

        public bool IsFullScreen { get; private set; }

        private static ScreenManager screen;
        public static ScreenManager Instance
        {
            get
            {
                if (screen == null)
                {
                    screen = new ScreenManager();
                }
                return screen;
            }
        }

        public void LoadContent(ContentManager content)
        {
            this.Content = new ContentManager(content.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
