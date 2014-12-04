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
        private Random rand = new Random((int)System.DateTime.UtcNow.Ticks);
        private Texture2D texture;
        private Rectangle screenBounds;
        private int frameCount;

        public List<Powerup> Powerups = new List<Powerup>();

        public PowerupManager(
            Texture2D texture,
            Rectangle screenBounds)
        {
            // Add some powerups maybe?
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