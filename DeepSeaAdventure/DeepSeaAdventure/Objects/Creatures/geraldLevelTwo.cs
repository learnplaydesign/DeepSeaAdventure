using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DeepSeaAdventure
{
    /* Class for gerald during the second level makes use of the unique Weapon, Super and health properties for this level.
     * */
    class geraldLevelTwo : creature
    {
        float superTimer;
        int currentSuper = 0;
        string weaponName;

        public geraldLevelTwo(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 vel) :
            base(tex, centre, pos, sourceRect, vel)
        {
            this.health = 1;
            weapon = new laserShot();
            weaponName = "Laser Shot";
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb, Color col)
        {
            base.Draw(gameTime, sb, Color.White);
            health = 3;
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            ProcessInput();
            base.Update(gameTime, viewportRect);

            superTimer += (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            firetime += (float)gameTime.ElapsedGameTime.Milliseconds / 1000;

            Velocity *= 0.0f;
            screenCollide(viewportRect);

            if (currentSuper >= 25 && currentSuper < 35)
            {
                weapon = new RocketLauncher();
                weaponName = "Rockets";

            }

            if (currentSuper >= 50 && currentSuper < 55)
            {
                weapon = new laserbeam();
                weaponName = "LAZER BEAM";
            }

            if (currentSuper >= 65)
            {
                weapon = new novalauncher();
                weaponName = "NOVA";
            }

            if (superTimer >= 4.0f)
            {
                decrementSuper();
                superTimer = 0.0f;
            }

            if (currentSuper <= 0)
            {
                currentSuper = 0;
            }

        }

        public void incrementSuper()
        {
            currentSuper++;
        }

        public void decrementSuper()
        {
            currentSuper -= 1;
        }

        protected void ProcessInput()
        {
#if !XBOX
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                Velocity.X -= 7.0f;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                Velocity.X += 7.0f;
            }

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                if (firetime >= weapon.getFireSpeed())
                {
                    firedBullets.Add(weapon.FireProjectile(screenPos));
                    firetime = 0.0f;
                }
            }

            //#endif

            //#if XBOX
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            Velocity.X += (gamePadState.ThumbSticks.Left.X*7);

            if(gamePadState.IsButtonDown(Buttons.A))
            {
                if (firetime >= weapon.getFireSpeed())
                {
                    firedBullets.Add(weapon.FireProjectile(screenPos));
                    firetime = 0.0f;
                }
            }

#endif
        }

        public string getWeaponName()
        {
            return weaponName;
        }



    }
}
