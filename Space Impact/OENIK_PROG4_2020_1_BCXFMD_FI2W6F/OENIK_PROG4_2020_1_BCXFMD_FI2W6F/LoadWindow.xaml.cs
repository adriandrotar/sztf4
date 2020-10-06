// <copyright file="LoadWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_BCXFMD_FI2W6F
{
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using BusinessLogic;

    /// <summary>
    /// Interaction logic for LoadWindow.xaml.
    /// </summary>
    public partial class LoadWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadWindow"/> class.
        /// </summary>
        public LoadWindow()
        {
            List<SavedGame> savedgameslist = SavedGamesFileHandler.LoadSavedGames();
            this.InitializeComponent();
            foreach (var item in savedgameslist)
            {
                this.savedGames.Items.Add(item.Name.ToString());
            }
        }

        /// <summary>
        /// Loads the selected game from the txt file.
        /// </summary>
        /// <param name="sender">The sender Object.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            string selected = this.savedGames.SelectedItem.ToString();
            this.LoadSaveGame(selected);
            this.Close();
            GameWindow gameWindow = new GameWindow();
            gameWindow.ShowDialog();
        }

        /// <summary>
        /// Sets the value of SAVE.txt.
        /// </summary>
        /// /// <param name="savename">Name of the save which needs to be loaded.</param>
        private void LoadSaveGame(string savename)
        {
            string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\SAVE.txt";
            StreamWriter sw = new StreamWriter(path, false);
            sw.Write(savename);
            sw.Close();
        }
    }
}
