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
        private string path;

        #endregion

        public override void LoadContent()
        {
            base.LoadContent();
            path = "Assets/Logo";
            logoTexture = content.Load<Texture2D>(path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (gameTime.TotalGameTime > TimeSpan.FromSeconds(3) || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                ScreenManager.Instance.LoadGameScreen(new SecondSplash());
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logoTexture, 
                new Rectangle(0, 0, (int)ScreenManager.Instance.Dimensions.X, (int)ScreenManager.Instance.Dimensions.Y),
                Color.White);
        }
    }
}
