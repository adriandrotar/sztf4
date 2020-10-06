// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLogic
{
    using System;
    using Repository;

    /// <summary>
    /// GameLogic class.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        private static readonly Random Rand = new Random();

        private readonly GameModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <param name="model"> A GameModel instance.</param>
        public GameLogic(GameModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Defines what a player instance does during a tick.
        /// </summary>
        public void PlayerTick()
        {
            foreach (var enemy in this.model.Enemies)
            {
                if (this.model.Player.IsCollision(enemy))
                {
                    enemy.CX = -10;
                    this.model.Player.Health -= 1;
                }

                for (int i = enemy.Ammunition.Count - 1; i >= 0; i--)
                {
                    if (enemy.Ammunition[i].IsCollision(this.model.Player))
                    {
                        this.model.Player.Health -= 1;
                        enemy.Ammunition.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        /// Method which moves the playership up on the screen.
        /// </summary>
        public void MoveUp()
        {
            if (this.model.Player.CY > 35)
            {
                this.model.Player.CY -= 10;
            }
        }

        /// <summary>
        /// Method which moves the playership down on the screen.
        /// </summary>
        public void MoveDown()
        {
            if (this.model.Player.CY < this.model.GameHeight - 35)
            {
                this.model.Player.CY += 10;
            }
        }

        /// <summary>
        /// Method which moves the playership left on the screen.
        /// </summary>
        public void MoveLeft()
        {
            if (this.model.Player.CX > 25)
            {
                this.model.Player.CX -= 10;
            }
        }

        /// <summary>
        /// Method which moves the playership right on the screen.
        /// </summary>
        public void MoveRight()
        {
            if (this.model.Player.CX < this.model.GameWidth - 30)
            {
                this.model.Player.CX += 10;
            }
        }

        /// <summary>
        /// Method which shoots a new player bullet.
        /// </summary>
        public void PlayerShoot()
        {
            this.model.Player.Ammunition.Add(new Bullet((this.model.Player.CX / 2) + 10, (this.model.Player.CY / 2) - 2));
        }

        /// <summary>
        /// Method which shoots a new enemy bullet.
        /// </summary>
        /// <param name="enemy"> The enemy which shoots the bullet.</param>
        public void EnemyShoot(EnemyShip enemy)
        {
            enemy.Ammunition.Add(new Bullet((enemy.CX / 2) - 10, (enemy.CY / 2) - 2));
        }

        /// <summary>
        /// Defines what a player bullet does in one tick.
        /// </summary>
        /// <param name="bullet">The bullet which moves.</param>
        public void BulletTick(Bullet bullet)
        {
            bullet.CX += 10;
        }

        /// <summary>
        /// Defines what an enemy bullet does in one tick.
        /// </summary>
        /// <param name="bullet">The bullet which moves.</param>
        public void EnemyBulletTick(Bullet bullet)
        {
            bullet.CX -= 15;
        }

        /// <summary>
        /// Method which moves the enemy.
        /// </summary>
        /// <param name="enemy">The enemy which moves.</param>
        public void EnemyMove(EnemyShip enemy)
        {
            if (Rand.Next(1, 11) % 2 == 0)
            {
                if (enemy.CY > 50)
                {
                    enemy.CY += 10;
                }
            }
            else
            {
                if (enemy.CY < this.model.GameHeight - 50)
                {
                    enemy.CY -= 10;
                }
            }
        }

        /// <summary>
        /// Defines what an enemy instance does in one tick.
        /// </summary>
        /// <param name="enemy">The enemy instance.</param>
        public void EnemyTick(EnemyShip enemy)
        {
            enemy.CX -= this.model.Player.DX;
            if (Rand.Next(1, 10) == 3)
            {
                this.EnemyMove(enemy);
            }

            if (Rand.Next(1, 50) == 2)
            {
                this.EnemyShoot(enemy);
            }

            for (int i = enemy.Ammunition.Count - 1; i >= 0; i--)
            {
                this.EnemyBulletTick(enemy.Ammunition[i]);

                if (enemy.Ammunition[i].CX <= -400)
                {
                    enemy.Ammunition.RemoveAt(i);
                }
            }

            if (enemy.CX < 0)
            {
                enemy.CX = this.model.GameWidth;
                enemy.CY = Rand.Next(20, (int)this.model.GameHeight);
            }

            for (int i = this.model.Player.Ammunition.Count - 1; i >= 0; i--)
            {
                if (this.model.Player.Ammunition[i].IsCollision(enemy))
                {
                    enemy.CX = -10;
                    this.model.Score += 10;
                    this.model.Player.Ammunition.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Defines what happens during one "game" tick.
        /// </summary>
        public void OneTick()
        {
            this.PlayerTick();
            foreach (EnemyShip enemy in this.model.Enemies)
            {
                this.EnemyTick(enemy);
            }

            for (int i = this.model.Player.Ammunition.Count - 1; i >= 0; i--)
            {
                this.BulletTick(this.model.Player.Ammunition[i]);

                if (this.model.Player.Ammunition[i].CX >= this.model.GameWidth - 10)
                {
                    this.model.Player.Ammunition.RemoveAt(i);
                }
            }
        }
    }
}