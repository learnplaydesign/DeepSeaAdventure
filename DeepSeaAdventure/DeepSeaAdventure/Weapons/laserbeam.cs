using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeepSeaAdventure
{
    class laserbeam : Weapon
    {
        public laserbeam()
        {
            fireSpeed = 2.0f;
        }

        /* Fire a new Projectile*/
        public override Projectile FireProjectile(Vector2 position)
        {
            projectileTexture = textureManager.Instance.useTexture("laserBeam");
            soundManager.Instance.PlaySound("Laser_Shoot");

            Projectile bullet = new beam(projectileTexture,
                    new Vector2(projectileTexture.Width / 2, projectileTexture.Height / 2),
                    new Vector2(position.X, position.Y -32),
                    new Rectangle(0, 0, projectileTexture.Width, projectileTexture.Height));            

            if (bullet != null)
            {
                return bullet;
            }

            return null;
        }


    }
}
