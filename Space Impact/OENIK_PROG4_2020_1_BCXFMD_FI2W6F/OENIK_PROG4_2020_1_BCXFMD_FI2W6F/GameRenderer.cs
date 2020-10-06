// <copyright file="GameRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_BCXFMD_FI2W6F
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using BusinessLogic;

    /// <summary>
    /// Defines a GameRenderer class.
    /// </summary>
    public class GameRenderer
    {
        private readonly Dictionary<string, Brush> myBrushes = new Dictionary<string, Brush>();
        private readonly Typeface font = new Typeface("Bahnschrift *");
        private readonly Point textLocation = new Point(10, 10);
        private readonly Rect bgRect;
        private readonly int oldScore = -1;
        private readonly int oldHealth = 4;
        private readonly GameModel model;
        private readonly string path = "OENIK_PROG4_2020_1_BCXFMD_FI2W6F.Images.";
        private FormattedText formattedText;
        private FormattedText formattedTextHealth;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRenderer"/> class.
        /// </summary>
        /// <param name="model"> A GameModel instance.</param>
        public GameRenderer(GameModel model)
        {
            this.model = model;
            this.bgRect = new Rect(0, 0, model.GameWidth, model.GameHeight);
        }

        private Brush PlayerBrush
        {
            get { return this.GetBrush(this.path + "playerpng.png"); }
        }

        private Brush EnemyBrush
        {
            get { return this.GetBrush(this.path + "enemypng.png"); }
        }

        private Brush BulletBrush
        {
            get { return this.GetBrush(this.path + "bullet2png.png"); }
        }

        private Brush BackgroundBrush
        {
            get { return this.GetBrush(this.path + "space.jpg"); }
        }

        private Brush EnemyBulletBrush
        {
            get { return this.GetBrush(this.path + "bullet3.png"); }
        }

        /// <summary>
        /// Builds the main display of the game.
        /// </summary>
        /// <param name="ctx"> DrawingContext instance.</param>
        public void BuildDisplay(DrawingContext ctx)
        {
            this.DrawBackGround(ctx);
            this.DrawBullet(ctx);
            this.DrawEnemyBullet(ctx);
            this.DrawEnemies(ctx);
            this.DrawPlayer(ctx);
            this.DrawScore(ctx);
            this.DrawHealth(ctx);
        }

        /// <summary>
        /// Returns the wanted imagebrush.
        /// </summary>
        /// <param name="fname">The name of the wanted image.</param>
        /// <returns>The wanted imagebrush.</returns>
        private Brush GetBrush(string fname)
        {
            if (!this.myBrushes.ContainsKey(fname))
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
                bmp.EndInit();
                ImageBrush ib = new ImageBrush(bmp);
                this.myBrushes[fname] = ib;
            }

            return this.myBrushes[fname];
        }

        /// <summary>
        /// Draws the health of the player on the board.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void DrawHealth(DrawingContext ctx)
        {
            if (this.oldHealth != this.model.Player.Health)
            {
                this.formattedTextHealth = new FormattedText("Health: < " + this.model.Player.Health.ToString() + " >", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, this.font, 20, Brushes.Red);
            }

            ctx.DrawText(this.formattedTextHealth, new Point(this.model.GameWidth - 110, 10));
        }

        /// <summary>
        /// Draws the score of the player on the board.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void DrawScore(DrawingContext ctx)
        {
            if (this.oldScore != this.model.Score)
            {
                this.formattedText = new FormattedText("Score: < " + this.model.Score.ToString() + " >", System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, this.font, 20, Brushes.Purple);
            }

            ctx.DrawText(this.formattedText, this.textLocation);
        }

        /// <summary>
        /// Draws the enemies on the board.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void DrawEnemies(DrawingContext ctx)
        {
            foreach (var enemy in this.model.Enemies)
            {
                ctx.DrawGeometry(this.EnemyBrush, null, enemy.RealArea);
            }
        }

        /// <summary>
        /// Draws the player on the board.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void DrawPlayer(DrawingContext ctx)
        {
            ctx.DrawGeometry(this.PlayerBrush, null, this.model.Player.RealArea);
        }

        /// <summary>
        /// Draws the background on the board.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void DrawBackGround(DrawingContext ctx)
        {
            ctx.DrawRectangle(this.BackgroundBrush, null, this.bgRect);
        }

        /// <summary>
        /// Draws the bullet on the board.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void DrawBullet(DrawingContext ctx)
        {
            foreach (var bullet in this.model.Player.Ammunition)
            {
                ctx.DrawGeometry(this.BulletBrush, null, bullet.RealArea);
            }
        }

        /// <summary>
        /// Draws the enemy bullet on the board.
        /// </summary>
        /// <param name="ctx">DrawingContext instance.</param>
        private void DrawEnemyBullet(DrawingContext ctx)
        {
            foreach (var enemy in this.model.Enemies)
            {
                foreach (var bullet in enemy.Ammunition)
                {
                    ctx.DrawGeometry(this.EnemyBulletBrush, null, bullet.RealArea);
                }
            }
        }
    }
}