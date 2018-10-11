using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Monogame_Sample_Project.App_Data.Managers;
using Monogame_Sample_Project.App_Data.Screens.LoadScreens.GameLoad;
using Monogame_Sample_Project.Models.Graphics;

namespace Monogame_Sample_Project.App_Data
{
    public class ScreenManager
    {
        public ScreenManager()
        {
            Dimensions = new Vector2(640, 480);
            IsFullScreen = false;
            currentScreen = new SplashScreen();

            xmlGameScreenManger = new XmlManager<GameScreen>
            {
                Type = currentScreen.Type
            };
            currentScreen = xmlGameScreenManger.Load($"Load/SplashScreen.xml");
        }

        #region Private

        private GameScreen currentScreen;
        private static ScreenManager screenManager;
        private XmlManager<GameScreen> xmlGameScreenManger;

        #endregion

        #region Public

        public static ScreenManager Instance
        {
            get
            {
                if (screenManager == null)
                {
                    screenManager = new ScreenManager();
                }
                return screenManager;
            }
        }

        public Vector2 Dimensions { get; private set; }
        public ContentManager Content { get; private set; }
        public bool IsFullScreen { get; private set; }

        #endregion

        public void LoadGameScreen(string path)
        {
            currentScreen.UnloadContent();
            currentScreen = xmlGameScreenManger.Load($"{path}.xml"); ;
            currentScreen.LoadContent();
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
