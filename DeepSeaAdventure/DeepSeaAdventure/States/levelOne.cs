using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeepSeaAdventure
{
    class levelOne : gameState
    {
        Score levelScore = Score.Instance;
        int localScore;
        int timeCounter;
        float timer;       

        /* Textures */
        Texture2D backgroundTex;
        Texture2D geraldTexture;
        Texture2D pelletTexture;
        Texture2D sharkTexture;

        /* Objects and  variables */
        geraldLevelOne Gerald;
        Shark Jaws;
        SoundEffectInstance sharkAmbient;

        float lastPellet = 0.0f;

        /* Fonts */
        SpriteFont kootenayFont;

        public levelOne(Game1 tg)
            : base(tg)
        {
            timeCounter = 90;
            levelScore.resetScore();
        }

        public override void LoadContent()
        {
            // Load Sounds
            soundManager.Instance.LoadSound("Applause");
            soundManager.Instance.LoadSound("SadTrombone");
            soundManager.Instance.LoadSound("Pop Cork");
            soundManager.Instance.LoadSound("Jaws");

            textureManager.Instance.LoadTexture("Underwater");
            textureManager.Instance.LoadTexture("Goldfish");
            textureManager.Instance.LoadTexture("Shark");
            textureManager.Instance.LoadTexture("pellets");

            // Assign All Sounds

            sharkAmbient = soundManager.Instance.getInstance("Jaws");

            // Assign texture to variable
            backgroundTex = textureManager.Instance.useTexture("Underwater");
            geraldTexture = textureManager.Instance.useTexture("Goldfish");
            pelletTexture = textureManager.Instance.useTexture("pellets");
            sharkTexture = textureManager.Instance.useTexture("Shark");

            // Load up all gameObjects
            Gerald = new geraldLevelOne(geraldTexture,
                new Vector2(geraldTexture.Width/2, geraldTexture.Height/2),
                new Vector2(300,100),
                new Rectangle(0,0, geraldTexture.Width, geraldTexture.Height),
                new Vector2(8,8));
            levelObjects.Add(Gerald);

            Jaws = new Shark(sharkTexture,
                new Vector2(sharkTexture.Width / 2, sharkTexture.Height / 2),
                new Vector2(-100, 100),
                new Rectangle(0, 0, sharkTexture.Width, sharkTexture.Height),
                new Vector2(0.1f, 0.1f), Gerald);         

            kootenayFont = theGame.Content.Load<SpriteFont>("Fonts\\Kootenay");
        }

        public override void UnloadContent()
        {
            soundManager.Instance.unloadContent();
            textureManager.Instance.unloadContent();
        }

        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {          
            base.Update(gameTime, viewportRect);
            
            /* Get the current score */
            localScore = levelScore.getScore();

            /* Check when the last Pellet dropped */
            lastPellet += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            /* Get the time that has passed, minus it from the counter then reset the timer
             * so it count individual seconds */
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            timeCounter -= (int)timer;

            if(timer >= 1.0f) timer = 0f;

            if (lastPellet >= 3.0f)
            {
                // Spawn new pellet
                levelObjects.Add(CreatePellet());
                lastPellet = 0.0f;
            }

            // Iterate through all object in levelObjects
            foreach (gameObject gO in levelObjects)
            {
                gO.Update(gameTime, viewportRect);
               
                //Check for collision with fish pellet
                if (Gerald.CollidesWith(gO))
                {
                    if (gO.GetType() == typeof(FishPellet))
                    {
                        deadLevelObjects.Add(gO);
                        soundManager.Instance.PlaySound("Pop Cork");
                        levelScore.incrementScore(1);
                    }
                }                
            }

            // If Jaws has been spawned.
            if (levelObjects.Contains(Jaws))
            {
                // DO per a pixel collision
                if (Gerald.perPixelCollide(Gerald.BoundingBox, Gerald.textureData, Jaws.BoundingBox, Jaws.textureData))
                {
                    endState(false);
                }
            }

            // IF half time elapsed spawn the shark.
            if (timeCounter < 45)
            {
                levelObjects.Add(Jaws);
                if (sharkAmbient.State == SoundState.Stopped)
                {
                    sharkAmbient.Volume = 0.75f;
                    sharkAmbient.IsLooped = true;
                    sharkAmbient.Play();
                }
                    

            }

            // if have more then 9 pellet spawn the shark
            if (localScore > 9)
            {
                levelObjects.Add(Jaws);

                if (sharkAmbient.State == SoundState.Stopped)
                {
                    sharkAmbient.Volume = 0.75f;
                    sharkAmbient.IsLooped = true;
                    sharkAmbient.Play();
                }
                    
            }
            
            //Clean up dead objects.
            foreach (gameObject gO in deadLevelObjects)
            {
                levelObjects.Remove(gO);
            }
           
            // Check Win Condition
            if(localScore >= 20)
            {
                soundManager.Instance.PlaySound("Applause");
                theGame.changeState(new winState(theGame));
            }

        }

        public override void Draw(GameTime gameTime, Rectangle viewPortRect, SpriteBatch sb)
        {
            base.Draw(gameTime, viewPortRect, sb);
            sb.Begin();
            sb.Draw(backgroundTex, viewPortRect, Color.White);
            
            // Iterate through all objects and draw them
            foreach(gameObject gO in levelObjects)
            {
                gO.Draw(gameTime, sb, Color.White);
            }

            // Interface
            sb.DrawString(kootenayFont,
                "Pellets Eaten: " + localScore.ToString(),
                new Vector2(10, 20),
                Color.Black);

            sb.DrawString(kootenayFont,
                "Time Left: " + timeCounter.ToString(),
                new Vector2(600, 20),
                Color.Black);
            sb.End();
        }


        /* Function to create pellets at random locations */
        private FishPellet CreatePellet()
        {
            Random rnd = new Random();

            return new FishPellet(pelletTexture,
                new Vector2(18,18),
                new Vector2(rnd.Next(10,790),10),
                new Rectangle(0, 0, 32, 32));
        }

        public override void endState(bool checkWin)
        {
            UnloadContent();

            if (checkWin)
            {
                
            }

            if (!checkWin)
            {
                deadLevelObjects.Add(Gerald);
                sharkAmbient.Stop();
                soundManager.Instance.PlaySound("SadTrombone");
                theGame.changeState(new loseState(theGame));
            }
        }

    }
}
