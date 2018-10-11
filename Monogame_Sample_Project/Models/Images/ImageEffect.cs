using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Sample_Project.Models.Images
{
    public class ImageEffect
    {
        protected Image imageRef;

        public bool IsActive;

        public ImageEffect()
        {
            IsActive = false;
        }

        public virtual void LoadContent(ref Image Image)
        {
            this.imageRef = Image;
        }
        public virtual void UnloadContent()
        {
        }
        public virtual void Update(GameTime gameTime)
        {
        }
    }
}
