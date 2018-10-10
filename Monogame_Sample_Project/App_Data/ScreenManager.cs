using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Monogame_Sample_Project.App_Data
{
    public class ScreenManager
    {
        public ScreenManager()
        {
            Dimensions = new Vector2(640, 480);
        }

        public Vector2 Dimensions { get; private set; }
        public ContentManager Content { get; private set; }

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
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

    }
}
