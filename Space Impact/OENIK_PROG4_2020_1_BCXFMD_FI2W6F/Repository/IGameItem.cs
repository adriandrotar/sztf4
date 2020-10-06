// <copyright file="IGameItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using System.Windows.Media;

    /// <summary>
    /// Defines the IGameItem interface.
    /// </summary>
    public interface IGameItem
    {
        /// <summary>
        /// Gets or sets the area of an item (0;0) centered.
        /// </summary>
        Geometry Area { get; set; }

        /// <summary>
        /// Gets or sets the degree of rotation.
        /// </summary>
        double RotDegree { get; set; }

        /// <summary>
        /// Gets or sets the health of an object.
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// Gets or sets the center x coordinate.
        /// </summary>
        double CX { get; set; }

        /// <summary>
        /// Gets or sets the center y coordinate.
        /// </summary>
        double CY { get; set; }

        /// <summary>
        /// Gets or sets the radian/degree.
        /// </summary>
        double Rad { get; set; }

        /// <summary>
        /// Gets the real area of an item.
        /// </summary>
        Geometry RealArea { get; }

        /// <summary>
        /// Checks if the object collides with another object.
        /// </summary>
        /// <param name="other">Another object.</param>
        /// <returns>True if collides, false if not.</returns>
        bool IsCollision(IGameItem other);

        /// <summary>
        /// Decides if an object is alive or not.
        /// </summary>
        /// <returns>True if the object is alive. False if it's dead.</returns>
        bool IsAlive();
    }
}