using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeepSeaAdventure
{
    class Chum : gameObject
    {
        geraldLevelTwo Gerald;

        public Chum(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, geraldLevelTwo Gerald)
            : base(tex, centre, pos, sourceRect)
        {
            this.Gerald = Gerald;
            Velocity = new Vector2(200, 200);
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            Vector2 difference;

            //difference between positions
            difference.X = Gerald.getPos().X - screenPos.X;
            difference.Y = Gerald.getPos().Y - screenPos.Y;

            // Get the direction that the shark needs to go in.
            difference.Normalize();

            // Move the chum
            screenPos = screenPos + Velocity * difference * (float)gameTime.ElapsedGameTime.TotalSeconds;     
        }

    }
}
