using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeepSeaAdventure
{
    /* Gun of the Squids */
    class squidGun : Weapon
    {
        public squidGun()
        {
            fireSpeed = 1.0f;
            
        }

        /* Fire a new projectile */
        public override Projectile FireProjectile(Vector2 position)
        {
            projectileTexture = textureManager.Instance.useTexture("ink");

            Projectile bullet = new ink(projectileTexture,
                         new Vector2(projectileTexture.Width / 2, projectileTexture.Height / 2),
                         new Vector2(position.X, position.Y + 32),
                         new Rectangle(0, 0, projectileTexture.Width, projectileTexture.Height));

            return bullet;
        }

    }
}
