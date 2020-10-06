// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_BCXFMD_FI2W6F
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml .
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly System.Media.SoundPlayer soundPlayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            string directory = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString() + "/Sounds/menusong.wav";
            this.soundPlayer = new System.Media.SoundPlayer(directory);
            this.soundPlayer.Play();

            this.InitializeComponent();
        }

        /// <summary>
        /// Escapes if ESC button is pressed.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The KeyEventArgs.</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Opens the ScoreBoardWindow.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void ScoreBoard(object sender, RoutedEventArgs e)
        {
            ScoreNameWindow scorenameWindow = new ScoreNameWindow();
            scorenameWindow.ShowDialog();
        }

        /// <summary>
        /// Opens AddNameWindow window.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void StartGame(object sender, RoutedEventArgs e)
        {
            AddNameWindow addNameWindow = new AddNameWindow();
            this.soundPlayer.Stop();
            addNameWindow.ShowDialog();
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Opens the LoadWindow.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void LoadGame(object sender, RoutedEventArgs e)
        {
            LoadWindow loadWindow = new LoadWindow();
            this.soundPlayer.Stop();
            loadWindow.ShowDialog();
        }
    }
}
