using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    /*
     * All Creatures extend from this class including the player controlled object
     */

    public abstract class creature : gameObject
    {
        protected float firetime = 0.0f;
        protected int health;
        protected Vector2[] movement;
        protected Weapon weapon;
        protected List<Projectile> firedBullets = new List<Projectile>();
        
        public creature(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 vel)
            : base(tex, centre, pos, sourceRect)
        {
            this.Velocity = vel;  
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb, Color col)
        {
            base.Draw(gameTime, sb, col);
        }       

       /* Take Damage */
       public virtual void takeDamage(int damage)
       {
           health -= damage;
       }

       /* Return health*/
       public virtual int getHealth()
       {
           return health;
       }

       /* Fire the creatures weapon */
       public void fireWeapon()
       {
           if (firetime >= weapon.getFireSpeed())
           {
               firedBullets.Add(weapon.FireProjectile(screenPos));
               firetime = 0.0f;
           }
       }

       /* Used by the level to keep track of projectiles */
       public virtual List<Projectile> getProjectiles()
       {
           return firedBullets;
       }

    }

}