using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Sample_Project.App_Data.Managers;
using Monogame_Sample_Project.Models.Graphics;
using Monogame_Sample_Project.Models.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Sample_Project.App_Data.Screens
{
    public class SplashScreen : GameScreen
    {
        #region Private

        private KeyboardState prevState;

        #endregion

        #region Public

        public Image Image;

        #endregion

        public override void LoadContent()
        {
            base.LoadContent();
            Image.LoadContent();
            Image.Position = new Vector2(
               (ScreenManager.Instance.Dimensions.X / 2) - Image.Texture.Width / 2,
               (ScreenManager.Instance.Dimensions.Y / 2) - Image.Texture.Height / 2);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);

            if (InputManager.Instance.KeyPressed(Keys.Enter, Keys.Z))
            {
                ScreenManager.Instance.ChangeScreens("TitleScreen");
            }

            prevState = Keyboard.GetState();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
