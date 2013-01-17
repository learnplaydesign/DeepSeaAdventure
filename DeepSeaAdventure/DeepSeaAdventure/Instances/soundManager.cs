using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

/*
 * Use the following singleton class to store and manage all sounds 
 */


namespace DeepSeaAdventure
{
    class soundManager
    {
        private static soundManager instance;
        private ContentManager content;
        private Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();

        private soundManager(Game game)
        {
            content = game.Content;
        }

        /* Initialise a new instance of the sound manager if one does not exist */
        public static void Initialise(Game game)
        {
            if (instance == null)
            {
                instance = new soundManager(game);
            }
        }

        public static soundManager Instance
        {
            get { return instance; }
        }

        /* Use to load any sounds from content in to the manager in the loadcontent method of a level state */
        public void LoadSound(string assetName)
        {
            sounds.Add(assetName, content.Load<SoundEffect>("sounds\\" + assetName));
        }

        /* To make use of a loaded sound */
        public void PlaySound(string name)
        {
            SoundEffect effect;
            if (sounds.TryGetValue(name, out effect))
                effect.Play();

        }

        /* Return a instance of the sound in the dictionary */
        public SoundEffectInstance getInstance(string name)
        {
            SoundEffect effect;
            SoundEffectInstance effectInstance;

            if (sounds.TryGetValue(name, out effect))
                effectInstance = effect.CreateInstance();

            else 
                effectInstance = null;

            return effectInstance;
        }

        public void unloadContent()
        {
            sounds.Clear();
        }



    }
}
