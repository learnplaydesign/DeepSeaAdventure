using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    /* Level one obstacle that tracks the players movement in an attempt to eat them */

    class Shark : creature
    {
        geraldLevelOne food;

        public Shark(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 vel, geraldLevelOne food) :
            base(tex, centre, pos, sourceRect, vel)
        {
            // Pass the player as a parameter so the shark can track the movement.
            this.food = food;

        }

        public override void Draw(GameTime gameTime, SpriteBatch sb, Color col)
        {
            base.Draw(gameTime, sb, col);
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            Vector2 difference;

            //difference between positions
            difference.X = food.getPos().X - screenPos.X;
            difference.Y = food.getPos().Y - screenPos.Y;

            // Get the direction that the shark needs to go in.
            difference.Normalize();

            // Move the shark
            screenPos = screenPos + Velocity * difference * (float)gameTime.ElapsedGameTime.TotalSeconds;                
          
        }


    }
}
