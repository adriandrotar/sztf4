// <copyright file="ScoreNameHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLogic
{
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Class which is a static helper class for highscore read/write.
    /// </summary>
    public static class ScoreNameHandler
    {
        /// <summary>
        /// Loads the name of the current player from the NAME.txt.
        /// </summary>
        /// <returns>The name of the current player.</returns>
        public static string NameLoad()
        {
            string output = string.Empty;
            StreamReader sr = new StreamReader(System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\NAME.txt");
            while (!sr.EndOfStream)
            {
                output += sr.ReadLine();
            }

            sr.Close();
            return output;
        }

        /// <summary>
        /// Loads the scores from the NAMESCORESLIST.txt.
        /// </summary>
        /// <returns>Returns a scorename list containing the name and the score of the players.</returns>
        public static List<ScoreName> LoadScoresNames()
        {
            List<ScoreName> output = new List<ScoreName>();
            StreamReader sr = new StreamReader(System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\NAMESCORESLIST.txt");
            while (!sr.EndOfStream)
            {
                string currentline = sr.ReadLine();
                string name = currentline.Split(':')[0];
                int score = int.Parse(currentline.Split(':')[1]);
                output.Add(new ScoreName() { Name = name, Score = score });
            }

            sr.Close();
            return output;
        }

        /// <summary>
        /// Writes the highscore to a NAMESCORELIST.txt file.
        /// </summary>
        /// <param name="input">A ScoreName list.</param>
        public static void WriteScoreNames(List<ScoreName> input)
        {
            StreamWriter sw = new StreamWriter(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\")) + @"\Repository\Persistent\NAMESCORESLIST.txt", false);
            foreach (var item in input)
            {
                string oneline = $"{item.Name}:{item.Score}";
                sw.WriteLine(oneline);
            }

            sw.Close();
        }
    }
}