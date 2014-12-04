using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Asteroid_Belt_Assault
{
    class CollisionManager
    {
        private AsteroidManager asteroidManager;
        private PlayerManager playerManager;
        private EnemyManager enemyManager;
        private ExplosionManager explosionManager;
        private PowerupManager powerupManager;

        private Vector2 offScreen = new Vector2(-500, -500);
        private Vector2 shotToAsteroidImpact = new Vector2(0, -20);
        private int enemyPointValue = 100;
        public int asteroidLife = 0;
        public int enemyLife = 0;
        public CollisionManager(
            AsteroidManager asteroidManager,
            PlayerManager playerManager,
            EnemyManager enemyManager,
            ExplosionManager explosionManager,
            PowerupManager powerupManager)
        {
            this.asteroidManager = asteroidManager;
            this.playerManager = playerManager;
            this.enemyManager = enemyManager;
            this.explosionManager = explosionManager;
        }

        private void checkAsteroidToEnemyCollisions()
        {
            foreach (Enemy enemy in enemyManager.Enemies)
            {
                foreach (Sprite asteroid in asteroidManager.Asteroids)
                {
                    if (asteroid.IsCircleColliding(enemy.EnemySprite.Center,
                        enemy.EnemySprite.CollisionRadius))
                    {
                        enemyLife += 3;
                        asteroid.Location = offScreen;
                        explosionManager.AddExplosion(
                                enemy.EnemySprite.Center,
                                enemy.EnemySprite.Velocity / 10);
                        if (enemyLife == 5)
                        {
                            enemy.Destroyed = true;
                            explosionManager.AddExplosion(
                                enemy.EnemySprite.Center,
                                enemy.EnemySprite.Velocity / 10);

                            


                            explosionManager.AddExplosion(
                                enemy.EnemySprite.Center,
                                enemy.EnemySprite.Velocity / 10);
                        }
                    }

                }
            }
        }
        
        
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
                        shot.Location = offScreen;
                        enemy.Destroyed = true;
                        playerManager.PlayerScore += enemyPointValue;
                        explosionManager.AddExplosion(
                            enemy.EnemySprite.Center,
                            enemy.EnemySprite.Velocity / 10);
                    }

                }
            }
        }

        private void checkShotToAsteroidCollisions()
        {
            foreach (Sprite shot in playerManager.PlayerShotManager.Shots)
            {
                foreach (Sprite asteroid in asteroidManager.Asteroids)
                {
                    if (shot.IsCircleColliding(
                        asteroid.Center,
                        asteroid.CollisionRadius))
                    {
                        asteroidLife = asteroidLife +1;
                        shot.Location = offScreen;
                        asteroid.Velocity += shotToAsteroidImpact;
                        if (asteroidLife == 5)
                        {
                            asteroid.Location = offScreen;
                            explosionManager.AddExplosion(
                            asteroid.Center,
                            asteroid.Velocity / 10);
                            asteroidLife = 0;
                        }
                    }
                }
            }
        }

        private void checkEnemyShotToAsteroidCollisions()
        {
            foreach (Sprite shot in enemyManager.EnemyShotManager.Shots)
            {
                foreach (Sprite asteroid in asteroidManager.Asteroids)
                {
                    if (shot.IsCircleColliding(
                        asteroid.Center,
                        asteroid.CollisionRadius))
                    {
                        asteroidLife = asteroidLife + 1;
                        shot.Location = offScreen;
                        asteroid.Velocity += shotToAsteroidImpact;
                        if (asteroidLife == 5)
                        {
                            asteroid.Location = offScreen;
                            explosionManager.AddExplosion(
                            asteroid.Center,
                            asteroid.Velocity / 10);
                            asteroidLife = 0;
                        }
                    }
                }
            }
        }
        private void checkShotToPlayerCollisions()
        {
            foreach (Sprite shot in enemyManager.EnemyShotManager.Shots)
            {
                if (shot.IsCircleColliding(
                    playerManager.playerSprite.Center,
                    playerManager.playerSprite.CollisionRadius))
                {
                    shot.Location = offScreen;
                    playerManager.Destroyed = true;
                    explosionManager.AddExplosion(
                        playerManager.playerSprite.Center,
                        Vector2.Zero);
                }
            }
        }

        private void checkEnemyToPlayerCollisions()
        {
            foreach (Enemy enemy in enemyManager.Enemies)
            {
                if (enemy.EnemySprite.IsCircleColliding(
                    playerManager.playerSprite.Center,
                    playerManager.playerSprite.CollisionRadius))
                {
                    enemy.Destroyed = true;
                    explosionManager.AddExplosion(
                        enemy.EnemySprite.Center,
                        enemy.EnemySprite.Velocity / 10);

                    playerManager.Destroyed = true;

                    explosionManager.AddExplosion(
                        playerManager.playerSprite.Center,
                        Vector2.Zero);
                }
            }
        }

        private void checkAsteroidToPlayerCollisions()
        {
            foreach (Sprite asteroid in asteroidManager.Asteroids)
            {
                if (asteroid.IsCircleColliding(
                    playerManager.playerSprite.Center,
                    playerManager.playerSprite.CollisionRadius))
                {
                    explosionManager.AddExplosion(
                        asteroid.Center,
                        asteroid.Velocity / 10);

                    asteroid.Location = offScreen;

                    playerManager.Destroyed = true;
                    explosionManager.AddExplosion(
                        playerManager.playerSprite.Center,
                        Vector2.Zero);
                }
            }
        }

        

        public void CheckCollisions()
        {
            checkAsteroidToEnemyCollisions();
            checkShotToEnemyCollisions();
            checkShotToAsteroidCollisions();
            checkEnemyShotToAsteroidCollisions();
            if (!playerManager.Destroyed)
            {
                checkShotToPlayerCollisions();
                checkEnemyToPlayerCollisions();
                checkAsteroidToPlayerCollisions();
            }
        }

    }
}
