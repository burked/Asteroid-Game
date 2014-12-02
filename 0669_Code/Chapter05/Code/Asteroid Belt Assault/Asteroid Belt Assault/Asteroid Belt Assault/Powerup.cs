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
            PowerupSprite.CollisionRadius = powerupRadius;
        }

            
       
        if()
        {
        }



            public bool IsActive()
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
     }

}
