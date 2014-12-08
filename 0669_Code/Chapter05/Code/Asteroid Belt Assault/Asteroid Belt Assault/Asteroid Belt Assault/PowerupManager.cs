using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class PowerupManager
    {


        private Texture2D texture;
        private Rectangle screenBounds;
        private RandomManager random;
        private int frameCount;
        private Enemy enemy;
        private Powerup powerup;
        private EnemyManager enemyManager;

        public List<Powerup> Powerups = new List<Powerup>();

        public PowerupManager(
            Texture2D texture,
            Rectangle screenBounds)
        {
            
            int i = 0;
            
            this.texture = texture;
            this.screenBounds = screenBounds;

        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }


    }
}