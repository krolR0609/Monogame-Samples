using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Monogame_Sample_Project.App_Data;
using System.Xml.Serialization;

namespace Monogame_Sample_Project.Models.Graphics
{
    public class GameScreen : IDisposable
    {
        public GameScreen()
        {
            Type = this.GetType();
            XmlPath = "Load/" + Type.Name + ".xml";
        }

        #region Protected

        protected ContentManager content;

        #endregion

        #region Public

        [XmlIgnore]
        public Type Type { get; set; }
        public string XmlPath;

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

        public void Dispose()
        {
            UnloadContent();
        }
    }
}
