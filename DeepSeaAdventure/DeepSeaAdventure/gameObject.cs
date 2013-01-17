using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

/* Abstract class for other objects in the game */

namespace DeepSeaAdventure
{
    public abstract class gameObject
    {
        
        protected Texture2D objectTexture;
        protected Vector2 centre;
        protected Vector2 screenPos;
        protected Rectangle sourceRect;
        protected float rotation = 0.0f;
        protected Vector2 Velocity;
        public Color[] textureData;
        protected int rows;
        protected int columns;
        protected int frames;
        protected int currentFrame;
        protected Vector2 gravity;

        //Initialize the bounding box for this object
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Math.Round(screenPos.X) - sourceRect.Width / 2,
                    (int)Math.Round(screenPos.Y) - sourceRect.Height / 2,
                    sourceRect.Width, sourceRect.Height);
            }
        }

        /* Initialise all properties of the object */
        public gameObject(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 gravity)
        {
            this.objectTexture = tex;
            this.centre = centre;
            this.screenPos = pos;
            this.sourceRect = sourceRect;
            this.textureData = new Color[objectTexture.Width * objectTexture.Height];
            this.objectTexture.GetData(textureData);
            this.gravity = gravity;
        }

        /* All object update logic goes here, for most gameObjects this is blank */

        public virtual void Update(GameTime gameTime, Rectangle viewportRect)
        {
            // Movement
            screenPos += Velocity;
        }

        /* Draw the object to the screen */

        public virtual void Draw(GameTime gameTime, SpriteBatch sb, Color col)
        {
            sb.Draw(objectTexture, screenPos, sourceRect, col, rotation, centre, 1.0f, SpriteEffects.None, 0);
        }

        /*Check for viewport edge collision */
        public virtual void screenCollide(Rectangle viewportRect)
        {
            //Check for collision with the side of the screen
            if (screenPos.X + sourceRect.Width / 2 > viewportRect.Right)
            {
                Velocity.X *= -1;
                screenPos.X = viewportRect.Right - sourceRect.Width / 2;
            }

            if (screenPos.X - sourceRect.Width / 2 < viewportRect.Left)
            {
                Velocity.X *= -1;
                screenPos.X = viewportRect.Left + sourceRect.Width / 2;
            }

            if (screenPos.Y - sourceRect.Height / 2 < viewportRect.Top)
            {
                Velocity.Y *= -1;
                screenPos.Y = viewportRect.Top + sourceRect.Height / 2;
            }

            if (screenPos.Y + sourceRect.Height / 2 > viewportRect.Bottom)
            {
                Velocity.Y *= -1;
                screenPos.Y = viewportRect.Bottom - sourceRect.Width / 2;
            }
        }

        /* Return the current position of the object*/
        public virtual Vector2 getPos()
        {
            return screenPos;
        }

        /*Set position of the object */

        public void setVelocity(float x, float y)
        {
            Velocity.X = x;
            Velocity.Y = y;
        }


        /* Check CollidesWith for box */
        public virtual bool CollidesWith(gameObject gmObject)
        {
            return this.BoundingBox.Intersects(gmObject.BoundingBox);
        }

        /* Use texture data to check collision */
        public bool perPixelCollide(Rectangle rectangleA, Color[] dataA, Rectangle rectangleB, Color[] dataB)
        {
            //Find the bounds of rectangle intersection
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            // Check every point within the intersection bounds
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Get the color of both pixels at this point
                    Color colorA = dataA[(x - rectangleA.Left) +
                                (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) +
                                (y - rectangleB.Top) * rectangleB.Width];

                    // If both pixels are not completely transparent,
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        // then an intersection has been found
                        return true;
                    }
                }
            }

            // No intersection found
            return false;
        }
    }
}
