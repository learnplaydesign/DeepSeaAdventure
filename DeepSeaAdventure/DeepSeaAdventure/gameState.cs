using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DeepSeaAdventure
{
    public abstract class gameState
    {
        protected Game1 theGame;
        protected List<gameObject> levelObjects = new List<gameObject>();
        protected List<gameObject> deadLevelObjects = new List<gameObject>();

        public gameState(Game1 tg)
        {
            theGame = tg;
        }

        public virtual void LoadContent() { }

        public virtual void UnloadContent() { }

        public virtual void Draw(GameTime gameTime, Rectangle viewPortRect, SpriteBatch sb) { }

        public virtual void Update(GameTime gameTime, Rectangle viewportRect) { }

        public virtual void endState(bool checkWin)
        {
        }

    }
}
