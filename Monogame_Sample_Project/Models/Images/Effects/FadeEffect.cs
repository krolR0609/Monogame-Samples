using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Monogame_Sample_Project.Models.Images.Effects
{
    public class FadeEffect : ImageEffect
    {
        public float FadeSpeed;
        public bool Increase;

        public FadeEffect()
        {
            FadeSpeed = 1;
            Increase = false;
        }

        public override void LoadContent(ref Image Image)
        {
            base.LoadContent(ref Image);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (imageRef.IsActive)
            {
                if (!Increase)
                {
                    imageRef.Alpha -= FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    imageRef.Alpha += FadeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (imageRef.Alpha < 0.0f)
                {
                    Increase = true;
                    imageRef.Alpha = 0.0f;
                }
                else if (imageRef.Alpha > 1.0f)
                {
                    Increase = false;
                    imageRef.Alpha = 1.0f;
                }
            }
            else
            {
                imageRef.Alpha = 1.0f;
            }
        }
    }
}
