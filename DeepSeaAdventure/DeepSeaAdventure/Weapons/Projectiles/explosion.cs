using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    class explosion : Projectile
    {
        float timeLastFrame = 0.0f;
        float timeBetweenFrames = 0.01f;

         public explosion(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, int rows = 1, int columns = 11, int frames = 11)
            : base(tex, centre, pos, sourceRect)
         {
            Velocity = new Vector2(0, 0);
            deathTime = 1.0f;
            damage = 4;
            this.rows = rows;
            this.columns = columns;
            this.frames = frames;
         }

         public override void Update(GameTime gameTime, Rectangle viewportRect)
         {
             base.Update(gameTime, viewportRect);
             /* Time at last frame*/
             timeLastFrame += (float)gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

             /* Animate the pellet */
             if (timeLastFrame >= timeBetweenFrames)
             {

                 currentFrame++;
                 currentFrame %= frames;
                 sourceRect.X = (currentFrame % columns) * sourceRect.Width;
                 sourceRect.Y = (currentFrame / columns) * sourceRect.Height;
                 timeLastFrame = 0.0f;
             }
         }
    }
}
