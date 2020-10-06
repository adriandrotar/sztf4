// <copyright file="EnemyShip.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// EnemyShip class.
    /// </summary>
    public class EnemyShip : GameItem
    {
        /// <summary>
        /// The height of the enemy ships.
        /// </summary>
        public const int RectHeight = 50;

        /// <summary>
        /// The width of the enemy ships.
        /// </summary>
        public const int RectWidth = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnemyShip"/> class.
        /// </summary>
        /// <param name="cx">The X coordinate of the enemy ship.</param>
        /// <param name="cy">The Y coordinate of the enemy ship.</param>
        public EnemyShip(double cx, double cy)
        {
            this.CX = cx;
            this.CY = cy;
            this.Ammunition = new List<Bullet>();

            GeometryGroup g = new GeometryGroup();
            Rect r1 = new Rect(-RectWidth / 2, -RectHeight / 2, RectWidth, RectHeight);
            g.Children.Add(new RectangleGeometry(r1));
            this.Area = g;
        }

        /// <summary>
        /// Gets or sets the Ammunition of the ship.
        /// </summary>
        public List<Bullet> Ammunition { get; set; }
    }
}