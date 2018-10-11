using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Monogame_Sample_Project.App_Data;

namespace Monogame_Sample_Project.Models.Graphics
{
    public class GameScreen
    {
        public GameScreen()
        {
        }

        #region Protected

        protected ContentManager content;

        #endregion

        #region Public

        public string Name { get; protected set; }

        #endregion

        public virtual void LoadContent()
        {
            content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
