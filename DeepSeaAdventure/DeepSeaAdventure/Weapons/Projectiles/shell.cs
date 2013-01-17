using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    class shell : Projectile 
    {
        gameObject target;

         public shell(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, gameObject target, int rows = 1, int columns = 8, int frames = 7)
            : base(tex, centre, pos, sourceRect)
         {
            Velocity = new Vector2(100, 100);
            deathTime = 5.0f;
            damage = 3;
            this.target = target;
         }

         public override void Update(GameTime gameTime, Rectangle viewportRect)
         {
             Vector2 difference;

             base.Update(gameTime, viewportRect);

             if (lifeSpan <= 4.0f)
             {

                 //difference between positions

                 difference.X = target.getPos().X - screenPos.X;
                 difference.Y = target.getPos().Y - screenPos.Y;

                 // Get the direction that the projectile needs to go in.
                 difference.Normalize();

                 // Move the projectile
                 screenPos = screenPos + Velocity * difference * (float)gameTime.ElapsedGameTime.TotalSeconds;
             }

             else
             {
                 screenPos.Y += 3.0f;
             }

         }

    }
}
