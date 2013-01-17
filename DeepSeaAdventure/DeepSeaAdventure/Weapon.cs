using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace DeepSeaAdventure
{
    /* Abstract Class that contains all weapon variables and the FireProjectile Function */

    public abstract class Weapon
    {
        protected Texture2D projectileTexture = textureManager.Instance.useTexture("laser");
        protected float fireSpeed;
        protected SoundEffectInstance weaponSound;

        public Weapon()        
        {
            fireSpeed = 0.3f;
            weaponSound = soundManager.Instance.getInstance("Laser_shoot");
        }
        
        public virtual Projectile FireProjectile(Vector2 position)
        {
            Projectile bullet = null;
            return bullet;
        }

        public virtual float getFireSpeed()
        {
            return fireSpeed;
        }

    }
}
