using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class Powerup
    {
        public Sprite PowerupSprite;
        public Vector2 PowerupFall = new Vector2(0, 10);
        private int powerupRadius = 15;
        public bool Applied = false;
        public Vector2 previousLocation = Vector2.Zero;
        private Vector2 currentWaypoint = Vector2.Zero;
        public Vector2 currentLocation = Vector2.Zero;
        private float speed = 25f;

        public Powerup(
            Texture2D texture,
            Vector2 location,
            Rectangle initialFrame,
            int frameCount)
        {
            PowerupSprite = new Sprite(
                location,
                texture,
                initialFrame,
                Vector2.Zero);

            for (int x = 1; x < frameCount; x++)
            {
                PowerupSprite.AddFrame(
                    new Rectangle(
                    initialFrame.X = (initialFrame.Width * x),
                    initialFrame.Y,
                    initialFrame.Width,
                    initialFrame.Height));
            }

            previousLocation = location;
            currentWaypoint = location;
            int powerupRadius = PowerupSprite.CollisionRadius;
            float powerupY = PowerupSprite.Location.Y;
            float powerupX = PowerupSprite.Location.X;
            float powerupCenterY = PowerupSprite.Center.Y;
            float powerupCenterX = PowerupSprite.Center.X;
            
        }

            
       
       



            public bool IsApplied()
            {
                if (Applied == true)
                {
                        return false;
                }

                if (PowerupSprite.Location.Y<=-15)
                {
                return false;
                }
                return true;
            }


            public void Update(GameTime gameTime)
            {
                if (IsApplied())
                {
                    Vector2 heading = currentWaypoint - PowerupSprite.Location;
                    if (heading != Vector2.Zero)
                    {
                        heading.Normalize();
                    }
                    heading *= speed;
                    PowerupSprite.Velocity = heading;
                    previousLocation = PowerupSprite.Location;
                    PowerupSprite.Update(gameTime);
                    PowerupSprite.Rotation =
                        (float)Math.Atan2(
                        PowerupSprite.Location.Y - previousLocation.Y,
                        PowerupSprite.Location.X - previousLocation.X);

                    
                }
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                if (IsApplied())
                {
                    PowerupSprite.Draw(spriteBatch);
                }
            }

     }

}
