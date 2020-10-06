// <copyright file="ScoreNameWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace OENIK_PROG4_2020_1_BCXFMD_FI2W6F
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using BusinessLogic;

    /// <summary>
    /// Interaction logic for ScoreNameWindow.xaml.
    /// </summary>
    public partial class ScoreNameWindow : Window
    {
        private readonly List<ScoreName> scoreNameList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreNameWindow"/> class.
        /// </summary>
        public ScoreNameWindow()
        {
            this.scoreNameList = ScoreNameHandler.LoadScoresNames();
            this.InitializeComponent();
            var orderedlist = this.scoreNameList.OrderByDescending(x => x.Score);
            foreach (var item in orderedlist)
            {
                string output = $"{item.Name} - {item.Score}";
                this.scorename.Items.Add(output);
            }
        }

        /// <summary>
        /// Close the current window.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs.</param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
