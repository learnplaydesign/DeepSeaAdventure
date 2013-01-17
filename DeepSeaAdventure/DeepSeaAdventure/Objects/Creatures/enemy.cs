using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeepSeaAdventure
{
    class enemy : creature
    {
        Weapon weapon;

        public enemy(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 vel, int health, Weapon weapon)
        : base(tex, centre, pos, sourceRect, vel)
        {
            this.health = health;
            this.weapon = weapon;
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb, Color col)
        {
            base.Draw(gameTime, sb, Color.White);
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            base.Update(gameTime, viewportRect);
        }
   
    }
}
