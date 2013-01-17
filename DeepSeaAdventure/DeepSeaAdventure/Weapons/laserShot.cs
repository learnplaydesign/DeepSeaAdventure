using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeepSeaAdventure
{
    /* Player Weapon */
    public class laserShot : Weapon
    {
        public laserShot()
        {
            fireSpeed = 0.3f;
            
        }

        /* Fire a new Projectile*/
        public override Projectile FireProjectile(Vector2 position)
        {
            projectileTexture = textureManager.Instance.useTexture("laser");
            soundManager.Instance.PlaySound("Laser_Shoot");

            Projectile bullet = new laser(projectileTexture,
                    new Vector2(projectileTexture.Width / 2, projectileTexture.Height / 2),
                    new Vector2(position.X, position.Y - 32),
                    new Rectangle(0, 0, projectileTexture.Width, projectileTexture.Height));            

            if (bullet != null)
            {
                return bullet;
            }

            return null;
        }


    }
}
