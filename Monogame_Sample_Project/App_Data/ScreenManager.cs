using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Monogame_Sample_Project.App_Data.Managers;
using Monogame_Sample_Project.App_Data.Screens;
using Monogame_Sample_Project.Models.Graphics;
using Monogame_Sample_Project.Models.Images;

namespace Monogame_Sample_Project.App_Data
{
    public class ScreenManager
    {
        public ScreenManager()
        {
            Dimensions = new Vector2(640, 480);
            IsFullScreen = false;
            currentScreen = new GameplayScreen();

            xmlGameScreenManger = new XmlManager<GameScreen>
            {
                Type = currentScreen.Type
            };
            //currentScreen = xmlGameScreenManger.Load($"Load/LogoScreen.xml");
        }

        #region Private

        private GameScreen currentScreen;
        private GameScreen nextScreen;

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
                    XmlManager<ScreenManager> xml = new XmlManager<ScreenManager>();
                    screenManager = xml.Load("Load/ScreenManager.xml");
                }
                return screenManager;
            }
        }

        [XmlIgnore]
        public GraphicsDevice GraphicsDevice;
        [XmlIgnore]
        public SpriteBatch SpriteBatch;
        [XmlIgnore]
        public Vector2 Dimensions { get; private set; }
        [XmlIgnore]
        public ContentManager Content { get; private set; }
        [XmlIgnore]
        public bool IsFullScreen { get; private set; }

        public Image Image;
        [XmlIgnore]
        public bool IsTransitioning { get; set; }

        #endregion

        public void ChangeScreens(string screenName)
        {
            nextScreen = (GameScreen)Activator.CreateInstance(Type.GetType(GameSettings.Instance.SCREENS_NAMESPACE + screenName));
            Image.IsActive = true;
            Image.FadeEffect.Increase = true;
            Image.Alpha = 0.0f;
            IsTransitioning = true;
        }

        private void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                Image.Update(gameTime);
                if (Image.Alpha == 1.0f)
                {
                    currentScreen.UnloadContent();
                    currentScreen = nextScreen;
                    xmlGameScreenManger.Type = currentScreen.Type;

                    if (File.Exists(currentScreen.XmlPath))
                    {
                        currentScreen = xmlGameScreenManger.Load(currentScreen.XmlPath);
                    }

                    currentScreen.LoadContent();
                }
                else if (Image.Alpha == 0.0f)
                {
                    Image.IsActive = false;
                    IsTransitioning = false;
                }
            }
        }

        public void LoadContent(ContentManager content)
        {
            this.Content = new ContentManager(content.ServiceProvider, "Content");
            currentScreen.LoadContent();
            Image.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            Transition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if (IsTransitioning)
            {
                Image.Draw(spriteBatch);
            }
        }
    }
}
