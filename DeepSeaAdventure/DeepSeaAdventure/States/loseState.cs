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
    class loseState : gameState
    {
        SpriteFont kootenayFont;

        public loseState(Game1 tg)
            : base(tg)
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
            kootenayFont = theGame.Content.Load<SpriteFont>("Fonts\\Kootenay");
            
        }
        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            base.Update(gameTime, viewportRect);

            if (keyboardState.IsKeyDown(Keys.Enter))
                theGame.changeState(new levelOne(theGame));
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
                theGame.changeState(new levelOne(theGame));

        }

        public override void Draw(GameTime gameTime, Rectangle viewPortRect, SpriteBatch sb)
        {
            base.Draw(gameTime, viewPortRect, sb);
            sb.Begin();
            sb.DrawString(kootenayFont, "YOU ARE LOSER", new Vector2(300, 10), Color.Bisque);
            sb.DrawString(kootenayFont, " Press Enter to try again", new Vector2(275, 400), Color.White);
            sb.End();
        }

    }
}
