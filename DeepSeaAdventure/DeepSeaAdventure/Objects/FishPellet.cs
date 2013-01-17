using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeepSeaAdventure
{
    /* The collectible for level one the Fish Pellet collides with gerald and is then removed from the
     * level.
     * The score is then iterated.
     */
     
    class FishPellet : gameObject
    {
        float timeLastFrame = 0.0f;
        float timeBetweenFrames = 0.1f;
        Random rnd;

        public FishPellet(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, int rows =1, int columns = 8, int frames = 7, int velX = 2, int velY = 1) : base(tex,centre,pos,sourceRect)
        {
            rnd = new Random();
            this.rows = rows;
            this.columns = columns;
            this.frames = frames;
            currentFrame = -1;
            Velocity.X = rnd.Next(-1, 1) ;
            Velocity.Y = velY;            
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            base.Update(gameTime, viewportRect);
            
            /* Time at last frame*/
            timeLastFrame += (float)gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            /* Animate the pellet */
            if (timeLastFrame >= timeBetweenFrames)
            {

                currentFrame++;
                currentFrame %= frames;
                sourceRect.X = (currentFrame % columns) * sourceRect.Width;
                sourceRect.Y = (currentFrame / columns) * sourceRect.Height;
                timeLastFrame = 0.0f;
            }

            /* Set the position of the pellet to the opposite side of the screen */
            if (getPos().X < 0)
            {
                screenPos.X = 790;
                screenPos.Y -= 200;
            }

            else if (getPos().X > 800)
            {
                screenPos.X = 10;
                screenPos.Y -= 200;
            }

            else if (getPos().Y > 600)
            {
                screenPos.Y = 10;
            }

        }

    }
}
