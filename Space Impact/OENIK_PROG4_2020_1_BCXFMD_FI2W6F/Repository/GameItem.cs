// <copyright file="GameItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Windows.Media;

    /// <summary>
    /// Class which defines a GameItem.
    /// </summary>
    public abstract class GameItem : IGameItem
    {
        /// <summary>
        /// Gets or sets the area of an item (0;0) centered.
        /// </summary>
        public Geometry Area { get; set; }

        /// <summary>
        /// Gets or sets the degree of rotation.
        /// </summary>
        public double RotDegree { get; set; }

        /// <summary>
        /// Gets or sets the health of an object.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets the center x coordinate.
        /// </summary>
        public double CX { get; set; }

        /// <summary>
        /// Gets or sets the center y coordinate.
        /// </summary>
        public double CY { get; set; }

        /// <summary>
        /// Gets or sets the radian/degree.
        /// </summary>
        public double Rad
        {
            get
            {
                return Math.PI * (this.RotDegree / 180);
            }

            set
            {
                this.RotDegree = (value / Math.PI) * 180;
            }
        }

        /// <summary>
        /// Gets the real area of an item.
        /// </summary>
        public Geometry RealArea
        {
            get
            {
                TransformGroup tg = new TransformGroup();
                tg.Children.Add(new TranslateTransform(this.CX, this.CY));
                tg.Children.Add(new RotateTransform(this.RotDegree, this.CX, this.CY));
                this.Area.Transform = tg;
                return this.Area.GetFlattenedPathGeometry();
            }
        }

        /// <summary>
        /// Checks if the object collides with another object.
        /// </summary>
        /// <param name="other">Another object.</param>
        /// <returns>True if collides, false if not.</returns>
        public bool IsCollision(IGameItem other)
        {
            return Geometry.Combine(this.RealArea, other.RealArea, GeometryCombineMode.Intersect, null).GetArea() > 0;
        }

        /// <summary>
        /// Decides if an object is alive or not.
        /// </summary>
        /// <returns>True if the object is alive. False if it's dead.</returns>
        public bool IsAlive()
        {
            if (this.Health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}