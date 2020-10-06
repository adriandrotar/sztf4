// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Repository;

    /// <summary>
    /// GameModel class.
    /// </summary>
    public class GameModel : IGameModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// </summary>
        /// <param name="w">The width of the game.</param>
        /// <param name="h">The height of the game.</param>
        public GameModel(double w, double h)
        {
            this.GameWidth = w;
            this.GameHeight = h;

            this.NumEnemies = 3;
            this.Player = new PlayerShip(50, h / 2)
            {
                Health = 3,
            };
            this.Enemies = new List<EnemyShip>();
            for (int i = 0; i < this.NumEnemies; i++)
            {
                this.Enemies.Add(new EnemyShip(h, i * w / this.NumEnemies));
            }
        }

        /// <summary>
        /// Gets or sets the number of enemies.
        /// </summary>
        public int NumEnemies { get; set; }

        /// <summary>
        /// Gets or sets the score of the player.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the Player.
        /// </summary>
        public PlayerShip Player { get; set; }

        /// <summary>
        /// Gets or sets the enemies.
        /// </summary>
        public List<EnemyShip> Enemies { get; set; }

        /// <summary>
        /// Gets or sets the Width of the game.
        /// </summary>
        public double GameWidth { get; set; }

        /// <summary>
        /// Gets or sets the Height of the game.
        /// </summary>
        public double GameHeight { get; set; }

        /// <summary>
        /// Initializes the map from the load file.
        /// </summary>
        /// <param name="filename">Name of the file which needs to be loaded.</param>
        public void InitMap(string filename)
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\";
            string fullname = path + filename + ".txt";
            StreamReader sr = new StreamReader(fullname);
            while (!sr.EndOfStream)
            {
                string currentline = sr.ReadLine();
                this.Player.Health = int.Parse(currentline.Split(':')[0]);
                this.Score = int.Parse(currentline.Split(':')[1]);
                this.Player.CX = double.Parse(currentline.Split(':')[2]);
                this.Player.CY = double.Parse(currentline.Split(':')[3]);
                int counter = 4;
                foreach (var item in this.Enemies)
                {
                    item.CX = double.Parse(currentline.Split(':')[counter]);
                    counter++;
                    item.CY = double.Parse(currentline.Split(':')[counter]);
                    counter++;
                }
            }

            sr.Close();
        }

        /// <summary>
        /// Saves the current state,details of the game in a txt file.
        /// </summary>
        public void SaveGame()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\";
            string name = DateTime.Now.ToString("yyyy_MM_dd_HH_mm");
            string fullname = path + name + ".txt";
            string output = $"{this.Player.Health}:{this.Score}:{this.Player.CX}:{this.Player.CY}";
            foreach (var item in this.Enemies)
            {
                output += $":{item.CX}:{item.CY}";
            }

            StreamWriter sr = new StreamWriter(fullname);
            sr.WriteLine(output);
            sr.Close();

            sr = new StreamWriter(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\SAVESLIST.txt", true);
            sr.WriteLine(name);
            sr.Close();
        }

        /// <summary>
        /// Gets the chosen saved game from the SAVE.txt.
        /// </summary>
        /// <returns>The content of the SAVE.txt.</returns>
        public string GetSave()
        {
            string output = string.Empty;
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\SAVE.txt";
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                output += sr.ReadLine();
            }

            sr.Close();
            return output;
        }

        /// <summary>
        /// Deletes the contents from the SAVE.txt.
        /// </summary>
        public void DeleteContent()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\SAVE.txt";
            StreamWriter sw = new StreamWriter(path, false);
            sw.Write(string.Empty);
            sw.Close();
        }
    }
}