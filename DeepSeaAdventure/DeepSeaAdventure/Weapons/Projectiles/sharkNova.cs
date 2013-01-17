using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeepSeaAdventure
{
    class sharkNova : nova
    {
        public sharkNova(Texture2D tex, Vector2 centre, Vector2 pos, Rectangle sourceRect)
            : base(tex, centre, pos, sourceRect)
        {
            Velocity = new Vector2(0, 5);
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {
            base.Update(gameTime, viewportRect);
        }

    }
}
