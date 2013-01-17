using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    /* 
     * Jellyfishes are just meant to be slow moving with more health then the squid, the challenge they propose is to avoid them
     */

    class Jellyfish : creature
    {
        public Jellyfish(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 vel) :
            base(tex, centre, pos, sourceRect, vel)
        {
            Velocity = new Vector2(0, 1);
            health = 3;
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            base.Update(gameTime, viewportRect);
        }
        
    }
}
