using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    /* This class handles all of the shared functions of Projectiles in the game, all Projectiles extends from
     * this class.
     */
     
    public class Projectile : gameObject
    {
        /*
         * bool live # If the projectile is live it will be updated
         * float lifeSpan # How long the projectile has lived
         * float deathTime # How long the bullet will stick around for
         * int damage # How much damage the projectile does
         */

        protected bool live = true; 
        protected float lifeSpan; 
        protected float deathTime; 
        protected int damage; 

        public Projectile(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect)
            :base(tex,centre,pos,sourceRect)
        {
            /* All projectile constructors set damage, death time and velocity */
            Velocity = new Vector2(0,-3);
            deathTime = 8.0f;
            damage = 1;
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            lifeSpan += (float)gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            /* Check death */
            if (lifeSpan >= deathTime)
            {
                live = false;
                lifeSpan = 0.0f;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb, Color col)
        {
            base.Draw(gameTime, sb, col);
        }

        public void setLive(bool isLive)
        {
            live = isLive;
        }

        public bool isLive()
        {
            return live;
        }

        /* Return damage of the Projectile*/
        public int getDamage()
        {
            return damage;
        }

        /*Check for viewport edge collision */
        public override void screenCollide(Rectangle viewportRect)
        {
            if (screenPos.Y - sourceRect.Height / 2 < viewportRect.Top)
            {
                live = false;
            }

            if (screenPos.Y + sourceRect.Height / 2 > viewportRect.Bottom)
            {
                live = false;
            }
        }

    }
}
