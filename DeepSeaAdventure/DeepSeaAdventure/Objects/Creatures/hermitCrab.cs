using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    class hermitCrab : creature
    {

        float timeLastVChange = 0.0f;
        float timeBetweenVChange = 4;

        public hermitCrab(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 vel, gameObject target) :
            base(tex, centre, pos, sourceRect, vel)
        {
            weapon = new crabGun(target);
            Velocity = new Vector2(1, 0.1f);
            health = 3;
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            base.Update(gameTime, viewportRect);

            firetime += (float)gameTime.ElapsedGameTime.Milliseconds / 1000;

            /* Time at velocity change*/
            timeLastVChange += (float)gameTime.ElapsedGameTime.Milliseconds / 1000f;

            /* Change Velocity */
            if (timeLastVChange >= timeBetweenVChange)
            {
                Velocity.X *= -1;
                timeLastVChange = 0.0f;
            }

            if (firetime >= weapon.getFireSpeed())
            {
                   firedBullets.Add(weapon.FireProjectile(screenPos));    
                   firetime = 0.0f;
            }
        }
    }
}
