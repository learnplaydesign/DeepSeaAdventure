using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DeepSeaAdventure
{
    class levelTwo : gameState
    {
        float EncounterTimer;

        /* Lists for level content */

        private List<creature> levelCreatures = new List<creature>();
        private List<Projectile> levelProjectiles = new List<Projectile>();

        /*Individual Creatures*/
        geraldLevelTwo Gerald;

        /* Textures */
        Texture2D sharkTexture;
        Texture2D geraldTexture;
        Texture2D squidTexture;
        Texture2D jellyTexture;
        Texture2D crabTexture;
        Texture2D chumTexture;
        Texture2D explosionTexture;
        Texture2D backgroundTexture;
        SpriteFont gameText;

        /* Encounter Bools */
        bool encounterOne; // One Squid Squad
        bool encounterTwo; // Two Squid Squad
        bool encounterThree; //Jelly Fish
        bool encounterFour; // Hermit Crabs
        bool encounterFive; // Jelly Fish and Two squid Squads
        bool encounterSix; // Jelly Fish and Hermit Crabs
        bool encounterSeven; // Jelly Fish, Hermit Crabs and a Squid Squad
        bool encounterEight; // Shark Boss

        /*float*/
        float messageOpacity = 1.0f;

        /* Sounds */
        SoundEffectInstance ambience;

        public levelTwo(Game1 tg)
            : base(tg)
        {}

        public override void LoadContent()
        {
            gameText = theGame.Content.Load<SpriteFont>("Fonts\\gameText");

            /* load textures */
            textureManager.Instance.LoadTexture("ink");
            textureManager.Instance.LoadTexture("laser");
            textureManager.Instance.LoadTexture("laserBeam");
            textureManager.Instance.LoadTexture("Gerald2");
            textureManager.Instance.LoadTexture("Squid");
            textureManager.Instance.LoadTexture("jellyfish");
            textureManager.Instance.LoadTexture("hermitcrab");
            textureManager.Instance.LoadTexture("chum");
            textureManager.Instance.LoadTexture("Bomb");
            textureManager.Instance.LoadTexture("explosion");
            textureManager.Instance.LoadTexture("shell");
            textureManager.Instance.LoadTexture("novaBall");
            textureManager.Instance.LoadTexture("sharkleveltwo");
            textureManager.Instance.LoadTexture("background");

            /* Load sound */
            soundManager.Instance.LoadSound("8bit-Space-Travel");
            soundManager.Instance.LoadSound("Laser_Shoot");
            soundManager.Instance.LoadSound("Hurt");
            soundManager.Instance.LoadSound("rocketShot");
            soundManager.Instance.LoadSound("inkShot");
            soundManager.Instance.LoadSound("novaShot");

            /* assign textures*/
            sharkTexture = textureManager.Instance.useTexture("sharkleveltwo");
            squidTexture = textureManager.Instance.useTexture("Squid");
            geraldTexture = textureManager.Instance.useTexture("Gerald2");
            jellyTexture = textureManager.Instance.useTexture("jellyfish");
            crabTexture = textureManager.Instance.useTexture("hermitcrab");
            chumTexture = textureManager.Instance.useTexture("chum");
            explosionTexture = textureManager.Instance.useTexture("explosion");
            backgroundTexture = textureManager.Instance.useTexture("background");

            /* assign sound instances */
            ambience = soundManager.Instance.getInstance("8bit-Space-Travel");

            /* Add objects*/
            Gerald = new geraldLevelTwo(geraldTexture,
                new Vector2(geraldTexture.Width / 2, geraldTexture.Height / 2),
                new Vector2(350, 700),
                new Rectangle(0, 0, geraldTexture.Width, geraldTexture.Height),
                new Vector2(8, 0));
            levelCreatures.Add(Gerald);

            levelObjects.AddRange(levelCreatures);
        }

        public override void UnloadContent()
        {
            textureManager.Instance.unloadContent();
            soundManager.Instance.unloadContent();
        }
        
        public override void Update(GameTime gameTime, Rectangle viewportRect)
        {    
            base.Update(gameTime, viewportRect);

            /* Start up the ambience track*/
            if (ambience.State == SoundState.Stopped)
            {
                ambience.Volume = 0.75f;
                ambience.IsLooped = true;
                ambience.Play();
            }

            /*Encounter Management*/
            EncounterTimer += (float)gameTime.ElapsedGameTime.Milliseconds / 1000.0f;            

            // Instruction Opacity
            if (encounterOne == false)
            {
                messageOpacity -= 0.0030f;
            }

            //Encounter One
            if (EncounterTimer >= 6.0f && encounterOne == false)
            {
                spawnSquidSquad(300, 0,10);
                encounterOne = true;
            }

            //Encounter Two
            if (EncounterTimer >= 18.0f && encounterTwo == false)
            {
                spawnSquidSquad(300, 0, 10);
                spawnSquidSquad(300, -200, 10);
                spawnSquidSquad(300, -400, 10);
                encounterTwo = true;
            }

            // Encounter Three
            if (EncounterTimer >= 30.0f && encounterThree == false)
            {
                spawnJellySquad(0, 0, 10);
                encounterThree = true;
            }

            // Encounter Four
            if (EncounterTimer >= 40.0f && encounterFour == false)
            {
                Score.Instance.incrementScore(500);
                spawnHermitSquad(300, 0, 2);
                spawnHermitSquad(100, -50, 2);
                spawnHermitSquad(100, -50, 2);
                encounterFour = true;
            }

            // Encounter Five
            if (EncounterTimer >= 50.0f && encounterFive == false)
            {

                spawnSquidSquad(300, 0, 10);
                spawnSquidSquad(300, -200, 10);
                spawnJellySquad(0, -400, 10);
                encounterFive = true;
            }

            // Encounter Six
            if (EncounterTimer >= 70.0f && encounterSix == false)
            {

                spawnSquidSquad(300, 0, 10);
                spawnSquidSquad(300, -200, 10);
                spawnJellySquad(0, -400, 10);
                encounterSix = true;
            }

            // Encounter Seven
            if (EncounterTimer >= 90.0f && encounterSeven == false)
            {

                spawnSquidSquad(300, 0, 10);
                spawnSquidSquad(300, -200, 10);
                spawnJellySquad(0, -400, 10);
                encounterSeven = true;
            }

            // Encounter Seven
            if (EncounterTimer >= 100.0f && encounterSeven == false)
            {

                spawnSquidSquad(300, 0, 10);
                spawnSquidSquad(300, -200, 10);
                spawnJellySquad(0, -400, 10);
                encounterSeven = true;
            }

            // Encounter Eight
            if (EncounterTimer >= 120.0f && encounterEight == false)
            {
                spawnShark(300, 64);
                encounterEight = true;
            }

            /* Update All Game Objects */
            foreach(gameObject gO in levelObjects)
            {
                gO.Update(gameTime, viewportRect);

                if (gO.GetType() == typeof(Chum))
                {
                    if(gO.CollidesWith(Gerald))
                    {
                        Gerald.incrementSuper();
                        deadLevelObjects.Add(gO);                        
                    }
                }

                if (gO.GetType() == typeof(rocket))
                {
                    foreach (creature critter in levelCreatures)
                    {
                        if (gO.CollidesWith(critter))
                        {
                            levelProjectiles.Add(new explosion(explosionTexture,
                                new Vector2(32,32),
                                new Vector2(gO.getPos().X,gO.getPos().Y-32),
                                new Rectangle(0, 0, (explosionTexture.Width/11), explosionTexture.Height)));
                            deadLevelObjects.Add(gO);
                        }
                    }
                }
            }

            /* Check bullet collisions or if a bullet is alive */
            foreach (Projectile bullet in levelProjectiles)
            {
                if (bullet.GetType() != typeof(ink))
                {
                    foreach (creature critter in levelCreatures)
                    {
                        if (bullet.perPixelCollide(bullet.BoundingBox, bullet.textureData, critter.BoundingBox, critter.textureData))
                        {
                            soundManager.Instance.PlaySound("Hurt");                          
                            critter.takeDamage(bullet.getDamage());
                            bullet.setLive(false);
                        }
                    }
                }

                /* If bullet is ink or shells, how does it behave */

                else if (bullet.GetType() == typeof(ink) || bullet.GetType() == typeof(shell))
                {
                    if (bullet.perPixelCollide(bullet.BoundingBox, bullet.textureData, Gerald.BoundingBox, Gerald.textureData))
                    {
                        bullet.setLive(false);
                        Gerald.takeDamage(bullet.getDamage());
                        soundManager.Instance.PlaySound("Hurt");
                    }
                }

                else if (bullet.GetType() == typeof(explosion))
                {
                    foreach (creature critter in levelCreatures)
                    {
                        if (bullet.CollidesWith(critter))
                        {
                            soundManager.Instance.PlaySound("Hurt");
                            bullet.setLive(false);
                            critter.takeDamage(bullet.getDamage());
                        }
                    }
                }

                // Logic that occurs at the end of a projectiles life cycle
                if (!bullet.isLive())
                {
                    deadLevelObjects.Add((gameObject)bullet);
                }
            }

            /* Check if any creatures are dead*/
            foreach(creature critter in levelCreatures)
            {
                if (critter.GetType() == typeof(geraldLevelTwo))
                {
                    if (critter.getHealth() <= 0)
                    {
                        endState(false);
                    }
                }

                // Creature is dead, spawn chum.
                if (critter.getHealth() <= 0)
                {
                    Score.Instance.incrementScore(100);
                    deadLevelObjects.Add(critter);
                    spawnChum(critter.getPos().X, critter.getPos().Y);
                }

                // Check collision between Gerald and all enemy types
                if (critter.GetType() == typeof(Squid) || critter.GetType() == typeof(Jellyfish) || critter.GetType() == typeof(hermitCrab))
                {
                    if (Gerald.perPixelCollide(Gerald.BoundingBox, Gerald.textureData,critter.BoundingBox,critter.textureData))
                    {
                        deadLevelObjects.Add(Gerald);
                        endState(false);
                    }
                }
            }

            /* Clean up all of the dead objects */
            foreach (gameObject gO in deadLevelObjects)
            {
                levelObjects.Remove(gO);

                // Creatures
                if (gO.GetType() == typeof(Squid) || gO.GetType() == typeof(geraldLevelTwo) || gO.GetType() == typeof(Jellyfish)
                    || gO.GetType() == typeof(hermitCrab) || gO.GetType() == typeof(SharkLevelTwo))
                {
                    if (gO.GetType() == typeof(SharkLevelTwo))
                    {
                        Score.Instance.incrementScore(1000);
                        endState(true);
                    }

                    levelCreatures.Remove((creature)gO);
                }

                // Projectiles
                if (gO.GetType() == typeof(laser) || gO.GetType() == typeof(rocket) || gO.GetType() == typeof(explosion) || gO.GetType() == typeof(shell)
                    || gO.GetType() == typeof(beam) || gO.GetType() == typeof(nova))
                {
                    levelProjectiles.Remove((Projectile)gO);
                }
            }

            updateLists();  
                     
        }

        public override void Draw(GameTime gameTime, Rectangle viewPortRect, SpriteBatch sb)
        {
            base.Draw(gameTime, viewPortRect, sb);

            sb.Begin();

            sb.Draw(backgroundTexture, new Vector2(0, 0), Color.White);

            /* Draw all of the objects in levelObjects*/
            foreach(gameObject gO in levelObjects)
            {
                gO.Draw(gameTime,sb,Color.White);
            }

            sb.DrawString(gameText, "Control Gerald with the arrow keys or left Stick", new Vector2(10, 100), Color.White * messageOpacity);
            sb.DrawString(gameText, "Fire with Spacebar or 'A'", new Vector2(10, 125), Color.White * messageOpacity);
            sb.DrawString(gameText, "Kill enemies quickly to gain better weaponry", new Vector2(10, 150), Color.White * messageOpacity);
            sb.DrawString(gameText, "Score:" + Score.Instance.getScore().ToString(), new Vector2(10, 10), Color.White * 0.75f);
            sb.DrawString(gameText, "SUPER:" + Gerald.getWeaponName(), new Vector2(10, 30), Color.White * 0.75f);

            sb.End();
        }

        /* Update all Lists including deleting dead or unneeded objects*/
        public void updateLists()
        {

            /* Update LevelObjects with projectiles, add creatures and fired projectiles to 
             * relevant list */
            foreach (creature critter in levelCreatures)
            {
                levelObjects.AddRange(critter.getProjectiles());
                levelProjectiles.AddRange(critter.getProjectiles());

                if (!levelObjects.Contains((gameObject)critter))
                {
                    levelObjects.Add(critter);
                }

                critter.getProjectiles().Clear();
            }

            foreach (Projectile bullet in levelProjectiles)
            {
                if (!levelObjects.Contains((gameObject)bullet))
                {
                    levelObjects.Add(bullet);
                }
            }

            deadLevelObjects.Clear();
        }

        public void spawnChum(float x,float y)
        {
            levelObjects.Add(new Chum(chumTexture,
                    new Vector2(chumTexture.Width / 2, chumTexture.Height / 2),
                    new Vector2(x,y),
                    new Rectangle(0, 0, chumTexture.Width, chumTexture.Height),
                    Gerald));
        }

        /* Spawn any Number(z) of squids at position 100 + x, 0 + y
         * (for spawning a series of squids)
         */
        public void spawnSquidSquad(int x, int y, int z)
        {
            for (int i = 0; i < z; i++)
            {
                levelCreatures.Add(new Squid(squidTexture,
                    new Vector2(squidTexture.Width / 2, squidTexture.Height / 2),
                    new Vector2(100+x, 0 + y),
                    new Rectangle(0, 0, squidTexture.Width, squidTexture.Height),
                    new Vector2(0, 0)));

                x += 32;
            }
        }

        /* Spawn any Number(z) of Jellyfish at position x, y
         * (for spawning a series of squids)
        */
        public void spawnJellySquad(int x, int y, int z)
        {
            for (int i = 0; i < z; i++)
            {
                levelCreatures.Add(new Jellyfish(jellyTexture,
                    new Vector2(jellyTexture.Width / 2, jellyTexture.Height / 2),
                    new Vector2(100 + x, 0 + y),
                    new Rectangle(0, 0, jellyTexture.Width, jellyTexture.Height),
                    new Vector2(0, 0)));

                x += 72;
            }
        }

        /* Spawn any Number(z) of hermit crabs at position x, y
         */
        public void spawnHermitSquad(int x, int y, int z)
        {
            for (int i = 0; i < z; i++)
            {
                levelCreatures.Add(new hermitCrab(crabTexture,
                    new Vector2(crabTexture.Width / 2, crabTexture.Height / 2),
                    new Vector2(100 + x, 0 + y),
                    new Rectangle(0, 0, crabTexture.Width, crabTexture.Height),
                    new Vector2(0, 0),
                    Gerald));

                x += 72;
            }
        }

        /* Spawn shark
         */
        public void spawnShark(int x, int y)
        {
            levelCreatures.Add(new SharkLevelTwo(sharkTexture,
                new Vector2(sharkTexture.Width / 2, sharkTexture.Height / 2),
                new Vector2(100, y),
                new Rectangle(0, 0, sharkTexture.Width, sharkTexture.Height),
                new Vector2(0, 0),
                Gerald));
        }
        /* End the state, check if win or lose */

        public override void endState(bool checkWin)
        {
            UnloadContent();
            

            if(checkWin)
            {
                theGame.changeState(new winstateTwo(theGame));
            }

            if(!checkWin)
            {
                Score.Instance.resetScore();                
                theGame.changeState(new loseStateTwo(theGame));                
            }

            ambience.Stop();

        }

    }
}
