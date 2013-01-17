using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    class SharkLevelTwo : creature
    {
        geraldLevelTwo food;

        public SharkLevelTwo(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 vel, geraldLevelTwo food) :
            base(tex, centre, pos, sourceRect, vel)
        {
            // Pass the player as a parameter so the shark can track the movement.
            this.food = food;
            health = 100;
            weapon = new sharkCannon();
            Velocity = new Vector2(300, 0);
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb, Color col)
        {
            base.Draw(gameTime, sb, col);
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            Vector2 difference;

            //difference between positions
            difference.X = food.getPos().X - screenPos.X;
            difference.Y = food.getPos().X - screenPos.Y;

            // Get the direction that the shark needs to go in.
            difference.Normalize();

            // Move the shark
            screenPos = screenPos + Velocity * difference * (float)gameTime.ElapsedGameTime.TotalSeconds;
            firetime += (float)gameTime.ElapsedGameTime.Milliseconds / 1000;

            if (firetime >= weapon.getFireSpeed())
            {
                firedBullets.Add(weapon.FireProjectile(screenPos));

                firetime = 0.0f;
            }
          
        }
    }
}
