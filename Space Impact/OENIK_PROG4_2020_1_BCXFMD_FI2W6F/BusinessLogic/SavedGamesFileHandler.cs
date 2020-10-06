// <copyright file="SavedGamesFileHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLogic
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// A class which handles the saved games.
    /// </summary>
    public class SavedGamesFileHandler
    {
        private static readonly string Logfile = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\SAVESLIST.txt";

        /// <summary>
        /// Loads the savedgames from the SAVESLIST.txt.
        /// </summary>
        /// <returns>Returns a savedgames list containing the save names from the txt file.</returns>
        public static List<SavedGame> LoadSavedGames()
        {
            List<SavedGame> savedgameslist = new List<SavedGame>();
            StreamReader sr = new StreamReader(Logfile);
            while (!sr.EndOfStream)
            {
                savedgameslist.Add(new SavedGame() { Name = sr.ReadLine() });
            }

            sr.Close();
            return savedgameslist;
        }
    }
}