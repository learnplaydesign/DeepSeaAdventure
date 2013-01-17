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
    class winstateTwo : gameState
    {
        SpriteFont gameText;

        public winstateTwo(Game1 tg)
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
            base.Update(gameTime, viewportRect);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
                theGame.changeState(new titleState(theGame));

        }

        public override void Draw(GameTime gameTime, Rectangle viewPortRect, SpriteBatch sb)
        {
            base.Draw(gameTime, viewPortRect, sb);
            sb.Begin();
            sb.DrawString(gameText, "CONGRATULATIONS YOU WIN", new Vector2(200, 10), Color.Bisque);
            sb.DrawString(gameText, "Final Score:" + Score.Instance.getScore().ToString(), new Vector2(300, 400), Color.White * 0.75f);

            sb.End();
        }

    }
}
