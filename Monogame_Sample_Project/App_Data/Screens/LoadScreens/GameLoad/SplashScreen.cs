using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Sample_Project.Models.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Sample_Project.App_Data.Screens.LoadScreens.GameLoad
{
    public class SplashScreen : GameScreen
    {
        #region Private

        private Texture2D logoTexture;
        private KeyboardState prevState;

        #endregion

        #region Public

        public string Path;

        #endregion

        public override void LoadContent()
        {
            base.LoadContent();
            logoTexture = content.Load<Texture2D>(Path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !prevState.IsKeyDown(Keys.Space))
            {
                ScreenManager.Instance.LoadGameScreen("Load/SplashScreen");
            }
            prevState = Keyboard.GetState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logoTexture, 
                new Rectangle(0, 0, (int)ScreenManager.Instance.Dimensions.X, (int)ScreenManager.Instance.Dimensions.Y),
                Color.White);
        }
    }
}
