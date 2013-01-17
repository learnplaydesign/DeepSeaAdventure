using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

/*
 * Use the following singleton class to store and manage all textures 
 */


namespace DeepSeaAdventure
{
    class textureManager
    {
        private static textureManager instance;
        private ContentManager content;
        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        private textureManager(Game game)
        {
            content = game.Content;
        }

        /* Initialise a new instance of the texture manager if one does not exist */
        public static void Initialise(Game game)
        {
            if (instance == null)
            {
                instance = new textureManager(game);
            }
        }

        public static textureManager Instance
        {
            get { return instance; }
        }

        /* Use to load any textures from content in to the manager in the loadcontent method of a level state */
        public void LoadTexture(string assetName)
        {
            textures.Add(assetName, content.Load<Texture2D>("Textures\\" + assetName));
        }

        /* To make use of a loaded texture */
        public Texture2D useTexture(string name)
        {
            Texture2D texture;
            textures.TryGetValue(name, out texture);

            return texture;
        }

        public void unloadContent()
        {
            textures.Clear();
        }

    }
}
