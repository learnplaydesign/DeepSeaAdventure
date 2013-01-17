using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeepSeaAdventure
{
    class crabGun : Weapon
    {

        gameObject target;

        public crabGun(gameObject target)
        {
            fireSpeed = 2.0f;
            this.target = target;
        }

        /* Fire a new projectile */
        public override Projectile FireProjectile(Vector2 position)
        {
            projectileTexture = textureManager.Instance.useTexture("shell");
            Projectile bullet = new shell(projectileTexture,
                         new Vector2(projectileTexture.Width / 2, projectileTexture.Height / 2),
                         new Vector2(position.X, position.Y + 32),
                         new Rectangle(0, 0, projectileTexture.Width, projectileTexture.Height),
                         target);

            return bullet;
        }

    }
}
