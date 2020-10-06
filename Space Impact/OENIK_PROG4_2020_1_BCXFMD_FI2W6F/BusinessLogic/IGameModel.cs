// <copyright file="IGameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLogic
{
    using System.Collections.Generic;
    using Repository;

    /// <summary>
    /// Defines an IGameModel interface.
    /// </summary>
    public interface IGameModel
    {
        /// <summary>
        /// Gets or sets the number of enemies.
        /// </summary>
        int NumEnemies { get; set; }

        /// <summary>
        /// Gets or sets the score of the player.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// Gets or sets the Player.
        /// </summary>
        PlayerShip Player { get; set; }

        /// <summary>
        /// Gets or sets the enemies.
        /// </summary>
        List<EnemyShip> Enemies { get; set; }

        /// <summary>
        /// Gets or sets the Width of the game.
        /// </summary>
        double GameWidth { get; set; }

        /// <summary>
        /// Gets or sets the Height of the game.
        /// </summary>
        double GameHeight { get; set; }

        /// <summary>
        /// Initializes the map from the load file.
        /// </summary>
        /// <param name="filename">Name of the file which needs to be loaded.</param>
        void InitMap(string filename);

        /// <summary>
        /// Saves the current state of the game.
        /// </summary>
        void SaveGame();

        /// <summary>
        /// Gets the wanted saved game from the SAVE.txt.
        /// </summary>
        /// <returns>The content of the SAVE.txt.</returns>
        string GetSave();

        /// <summary>
        /// Deletes the content from the SAVE.txt.
        /// </summary>
        void DeleteContent();
    }
}