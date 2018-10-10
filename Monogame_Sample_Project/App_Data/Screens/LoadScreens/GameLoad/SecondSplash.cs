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
    public class SecondSplash : GameScreen
    {
        Texture2D logoTexture;
        string path;
        public override void LoadContent()
        {
            base.LoadContent();
            path = "Assets/MonoGameLogo";
            logoTexture = content.Load<Texture2D>(path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logoTexture, 
                new Rectangle(0, 0, (int)ScreenManager.Instance.Dimensions.X, (int)ScreenManager.Instance.Dimensions.Y),
                Color.White);
        }
    }
}
