using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Classes
{
    /// <summary>
    /// class to store data about music question
    /// </summary>
    public class MusicQuestion : Question, IComparable<Question>, IEquatable<Question>
    {
        public string FileName { get; set; }

        /// <summary>
        /// constructor with multiple parameters, calls base class constructor
        /// </summary>
        /// <param name="theme">given theme</param>
        /// <param name="level">given level</param>
        /// <param name="author">given author</param>
        /// <param name="questionText">given question text</param>
        /// <param name="answer">given answer</param>
        /// <param name="points">given points</param>
        /// <param name="fileName">given filename</param>
        public MusicQuestion(string theme, string level, string author, string questionText, string answer, int points, string fileName) : base(theme, level, author, questionText, answer, points)
        {
            FileName = fileName;
        }
        /// <summary>
        /// overriden tostring method to return formatted data about MusicQuestion
        /// </summary>
        /// <returns>formatted data</returns>
        public override string ToString()
        {
            return base.ToString() + String.Format(" {0,-13} | {1,-48} |", FileName, "-");
        }

        /// <summary>
        /// formats data to csv string
        /// </summary>
        /// <returns>returns csv formatted data</returns>
        public override string ToCSVString()
        {
            return base.ToCSVString() + String.Format("{0};{1}", FileName, "-");
        }

        /// <summary>
        /// overrides parent class CompareTo method, to compare by filenames
        /// </summary>
        /// <param name="question">other question</param>
        /// <returns>returns int value based on the comparison</returns>
        public override int CompareTo(Question question)
        {
            return this.FileName.CompareTo((question as MusicQuestion).FileName);
        }
        /// <summary>
        /// stores properties in list of string
        /// </summary>
        /// <returns>list of properties</returns>
        public override List<string> GetProperties()
        {
            List<string> full = base.GetProperties();
            full.Add(FileName);
            full.Add("-");
            return full;
        }
    }
}