// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_BCXFMD_FI2W6F
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using BusinessLogic;

    /// <summary>
    /// Defines a GameControl class.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        private readonly List<ScoreName> scoreNamesList;
        private GameLogic logic;
        private GameModel model;
        private GameRenderer renderer;
        private DispatcherTimer mainTimer;
        private System.Media.SoundPlayer soundPlayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.GameControl_Loaded;
            this.scoreNamesList = ScoreNameHandler.LoadScoresNames();
        }

        /// <summary>
        /// Method which defines what happens on render.
        /// </summary>
        /// <param name="drawingContext">A drawingcontext instance.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                this.renderer.BuildDisplay(drawingContext);
            }
        }

        /// <summary>
        /// Method which sets up the game.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The args of the routedevent.</param>
        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new GameModel(this.ActualWidth, this.ActualHeight);
            this.logic = new GameLogic(this.model);
            this.renderer = new GameRenderer(this.model);
            string fileName = this.model.GetSave();
            if (fileName.Length > 1)
            {
                this.model.DeleteContent();
                this.model.InitMap(fileName);
            }

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += this.Win_KeyDown;
                this.mainTimer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(40),
                };
                this.mainTimer.Tick += this.MainTimer_Tick;
                this.mainTimer.Start();
            }

            this.InvalidateVisual();
        }

        /// <summary>
        /// The basic control of the game.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The args of the routedevent.</param>
        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W: this.logic.MoveUp(); break;
                case Key.S: this.logic.MoveDown(); break;
                case Key.A: this.logic.MoveLeft(); break;
                case Key.D: this.logic.MoveRight(); break;
                case Key.Space: this.logic.PlayerShoot(); break;
                case Key.P: this.mainTimer.IsEnabled = !this.mainTimer.IsEnabled; break;
                case Key.X: this.model.SaveGame(); this.mainTimer.IsEnabled = !this.mainTimer.IsEnabled; MessageBox.Show("GAME SAVED"); break;
            }

            this.InvalidateVisual();
        }

        /// <summary>
        /// The maintimer method.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The args of the routedevent.</param>
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            string directory = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString() + "/Sounds/gameover.wav";
            this.soundPlayer = new System.Media.SoundPlayer(directory);

            this.logic.OneTick();
            this.InvalidateVisual();
            if (this.model.Player.IsAlive() == false)
            {
                this.soundPlayer.Play();
                this.mainTimer.IsEnabled = !this.mainTimer.IsEnabled;
                MessageBox.Show("YOU DIED!\nYOUR SCORE WAS: " + this.model.Score.ToString());
                this.scoreNamesList.Add(new ScoreName() { Name = ScoreNameHandler.NameLoad(), Score = this.model.Score });
                ScoreNameHandler.WriteScoreNames(this.scoreNamesList);
            }
        }
    }
}