// <copyright file="Bullet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Repository
{
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Bullet class.
    /// </summary>
    public class Bullet : GameItem
    {
        /// <summary>
        /// The height of the bullets.
        /// </summary>
        public const int RectHeight = 10;

        /// <summary>
        /// The width of the bullets.
        /// </summary>
        public const int RectWidth = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bullet"/> class.
        /// </summary>
        /// <param name="cx">The X coordinate of the bullet.</param>
        /// <param name="cy">The Y coordinate of the bullet.</param>
        public Bullet(double cx, double cy)
        {
            this.CX = cx;
            this.CY = cy;

            GeometryGroup g = new GeometryGroup();
            Rect r1 = new Rect(cx, cy, RectWidth, RectHeight);
            g.Children.Add(new RectangleGeometry(r1));
            this.Area = g;
        }
    }
}