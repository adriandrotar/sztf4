// <copyright file="AddNameWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_BCXFMD_FI2W6F
{
    using System.IO;
    using System.Windows;

    /// <summary>
    /// Interaction logic for AddNameWindow.xaml.
    /// </summary>
    public partial class AddNameWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddNameWindow"/> class.
        /// </summary>
        public AddNameWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Saves the name of the player then starts the game.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void EnterName_Click(object sender, RoutedEventArgs e)
        {
            string name = this.nameText.Text;
            this.LoadNameToTxt(name);
            this.Close();
            GameWindow gameWindow = new GameWindow();
            gameWindow.ShowDialog();
        }

        /// <summary>
        /// Sets the value of NAME.txt.
        /// </summary>
        /// /// <param name="name">Name of the player which needs to be saved.</param>
        private void LoadNameToTxt(string name)
        {
            string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\NAME.txt";
            StreamWriter sw = new StreamWriter(path, false);
            sw.Write(name);
            sw.Close();
        }
    }
}
