// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLogic
{
    using Repository;

    /// <summary>
    /// Defines the IGameLogic interface.
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// Defines what a player instance does during a tick.
        /// </summary>
        void PlayerTick();

        /// <summary>
        /// Method which moves the playership up on the screen.
        /// </summary>
        void MoveUp();

        /// <summary>
        /// Method which moves the playership down on the screen.
        /// </summary>
        void MoveDown();

        /// <summary>
        /// Method which moves the playership left on the screen.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Method which moves the playership right on the screen.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Method which shoots a new player bullet.
        /// </summary>
        void PlayerShoot();

        /// <summary>
        /// Method which shoots a new enemy bullet.
        /// </summary>
        /// <param name="enemy"> The enemy which shoots the bullet.</param>
        void EnemyShoot(EnemyShip enemy);

        /// <summary>
        /// Defines what a player bullet does in one tick.
        /// </summary>
        /// <param name="bullet">The bullet which moves.</param>
        void BulletTick(Bullet bullet);

        /// <summary>
        /// Defines what an enemy bullet does in one tick.
        /// </summary>
        /// <param name="bullet">The bullet which moves.</param>
        void EnemyBulletTick(Bullet bullet);

        /// <summary>
        /// Method which moves the enemy.
        /// </summary>
        /// <param name="enemy">The enemy which moves.</param>
        void EnemyMove(EnemyShip enemy);

        /// <summary>
        /// Defines what an enemy instance does in one tick.
        /// </summary>
        /// <param name="enemy">The enemy instance.</param>
        void EnemyTick(EnemyShip enemy);

        /// <summary>
        /// Defines what happens during one "game" tick.
        /// </summary>
        void OneTick();
    }
}