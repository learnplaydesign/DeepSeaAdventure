using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DeepSeaAdventure
{
    class geraldLevelOne : creature
    {
   
        public geraldLevelOne(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect, Vector2 vel) : 
            base(tex,centre,pos,sourceRect,vel)
        {}

        public override void Draw(GameTime gameTime, SpriteBatch sb, Color col)
        {
            base.Draw(gameTime, sb, Color.White);
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            ProcessInput();
            base.Update(gameTime, viewportRect);
            screenCollide(viewportRect);
            Velocity *= 0.0f;
        }

        protected void ProcessInput()
        {
#if !XBOX
            KeyboardState keyboardState = Keyboard.GetState();
            if(keyboardState.IsKeyDown(Keys.Left))
            {
                Velocity.X -= 8.0f;
            }
            
            if(keyboardState.IsKeyDown(Keys.Right))
            {
                Velocity.X += 8.0f;
            }

            if(keyboardState.IsKeyDown(Keys.Up))
            {
                Velocity.Y -= 8.0f;
            }

            if(keyboardState.IsKeyDown(Keys.Down))
            {
                Velocity.Y += 8.0f;
            }
//#endif

//#if XBOX
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            Velocity.X += gamePadState.ThumbSticks.Left.X*8;
            Velocity.Y -= gamePadState.ThumbSticks.Left.Y*8;
     
#endif
            if (Velocity.X == 0)
            {
                if (Velocity.Y > 0)
                    rotation = MathHelper.PiOver2;
                else if (Velocity.Y < 0)
                    rotation = -MathHelper.PiOver2;
            }
            else
            {
                rotation = (float)(Math.Atan2(Velocity.Y, Velocity.X));
            }

        }

    }
}
