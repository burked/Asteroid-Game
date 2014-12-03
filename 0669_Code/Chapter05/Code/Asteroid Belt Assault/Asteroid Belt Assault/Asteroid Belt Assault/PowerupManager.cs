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
        private Rectangle initialFrame;
        private int frameCount;

        

        public List<Powerup> Powerups = new List<Powerup>();

        private EnemyManager enemyManager;
        private PlayerManager playerManager;
        private AsteroidManager asteroidManager;

        private void checkShotToEnemyCollisions()
        {
            foreach (Sprite shot in playerManager.PlayerShotManager.Shots)
            {
                foreach (Enemy enemy in enemyManager.Enemies)
                {
                    if (shot.IsCircleColliding(
                        enemy.EnemySprite.Center,
                        enemy.EnemySprite.CollisionRadius))
                    {
                        

    }
}
