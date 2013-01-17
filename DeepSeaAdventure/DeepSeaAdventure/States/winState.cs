using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DeepSeaAdventure
{
    class winState : gameState
    {
        SpriteFont gameText;

        public winState(Game1 tg)
            : base(tg)
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
            gameText = theGame.Content.Load<SpriteFont>("Fonts\\gameText");
        }
        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            base.Update(gameTime, viewportRect);            

            if (keyboardState.IsKeyDown(Keys.Enter))
                theGame.changeState(new levelTwo(theGame));
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
                theGame.changeState(new levelTwo(theGame));

        }

        public override void Draw(GameTime gameTime, Rectangle viewPortRect, SpriteBatch sb)
        {
            base.Draw(gameTime, viewPortRect, sb);
            sb.Begin();
            sb.DrawString(gameText, "CONGRATULATIONS YOU WIN", new Vector2(300,10), Color.White);
            sb.DrawString(gameText, " Press enter for the next level", new Vector2(275, 400), Color.White);
            sb.End();
        }

    }
}
