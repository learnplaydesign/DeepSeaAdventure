using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DeepSeaAdventure
{
    /* Title screen state that display all title information including the ability to move on to level one */
    class titleState : gameState
    {
        SpriteFont kootenayFont;
        Vector2 messagePosition = new Vector2(300, 10);
        String messageString = "Deep Sea Adventure";

        public titleState(Game1 tg)
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

            // Debug Only
            if (keyboardState.IsKeyDown(Keys.F2))
                theGame.changeState(new levelTwo(theGame));

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
                theGame.changeState(new levelOne(theGame));

        }

        public override void Draw(GameTime gameTime, Rectangle viewPortRect, SpriteBatch sb)
        {
            base.Draw(gameTime, viewPortRect, sb);
            sb.Begin();
            sb.DrawString(kootenayFont, messageString, messagePosition, Color.Bisque);
#if !Xbox
            sb.DrawString(kootenayFont, " Press enter to Begin", new Vector2(275, 400), Color.White);
#endif
#if XBOX
            sb.DrawString(kootenayFont, " Press Start to Begin", new Vector2(275, 400), Color.White);
#endif
            sb.End();
        }

    }

}
