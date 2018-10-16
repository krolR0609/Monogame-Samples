using Monogame_Sample_Project.Models.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Monogame_Sample_Project.Models.Game;
using Monogame_Sample_Project.App_Data.Managers;

namespace Monogame_Sample_Project.App_Data.Screens
{
    public class GameplayScreen : GameScreen
    {
        private Player player;

        public override void LoadContent()
        {
            base.LoadContent();
            XmlManager<Player> xmlManager = new XmlManager<Player>();
            player = xmlManager.Load("Load/Gameplay/Player.xml");
            player.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            player.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            player.Draw(spriteBatch);
        }
    }
}
