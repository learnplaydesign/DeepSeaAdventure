using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    /* 
     * Create a Squid enemy that has a small amount of health but moves fast
     */

    class Squid : creature
    {
        float timeLastVChange = 0.0f;
        float timeBetweenVChange = 1;
        Random rand;
        
        public Squid(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 vel) :
            base(tex, centre, pos, sourceRect, vel)
        {
            weapon = new squidGun();
            health = 1;
            Velocity = new Vector2(-4,1);
            rand = new Random();
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            base.Update(gameTime, viewportRect);

            firetime += (float)gameTime.ElapsedGameTime.Milliseconds / 1000;

            /* Time at velocity change*/
            timeLastVChange += (float)gameTime.ElapsedGameTime.Milliseconds /1000f;

           /* Change Velocity */
            if (timeLastVChange >= timeBetweenVChange)
            {
                Velocity.X *= -1;
                timeLastVChange = 0.0f;
            }

            if (firetime >= weapon.getFireSpeed())
            {
                if (rand.Next(0,4) == 2)
                {
                    firedBullets.Add(weapon.FireProjectile(screenPos));  
                }
                firetime = 0.0f;
            }

        }






    }
}
