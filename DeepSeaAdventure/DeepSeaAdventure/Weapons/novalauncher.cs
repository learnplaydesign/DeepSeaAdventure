using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DeepSeaAdventure
{
    class novalauncher : Weapon
    {
        public novalauncher()
        {
            fireSpeed = 0.25f;            
        }

        /* Fire a new Projectile*/
        public override Projectile FireProjectile(Vector2 position)
        {
            projectileTexture = textureManager.Instance.useTexture("novaBall");
            soundManager.Instance.PlaySound("novaShot");

            Projectile bullet = new nova(projectileTexture,
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
