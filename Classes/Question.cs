using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Classes
{
    /// <summary>
    /// abstract class to store data about question
    /// </summary>
    public abstract class Question : IEquatable<Question>, IComparable<Question>
    {
        public string Theme { get; set; }
        public string Level { get; set; }
        public string Author { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public int Points { get; set; }
        
        /// <summary>
        /// method with multiple parameters
        /// </summary>
        /// <param name="theme">given theme</param>
        /// <param name="level">given level</param>
        /// <param name="author">given author</param>
        /// <param name="questionText">given question text</param>
        /// <param name="answer">given answer</param>
        /// <param name="points">given points</param>
        protected Question(string theme, string level, string author, string questionText, string answer, int points)
        {
            Theme = theme;
            Level = level;
            Author = author;
            QuestionText = questionText;
            Answer = answer;
            Points = points;
        }
        /// <summary>
        /// overriden tostring method to return formatted data about Question
        /// </summary>
        /// <returns>formatted data</returns>
        public override string ToString()
        {
            return String.Format("| {0,-20} | {1,12} | {2,-8} | {3,-55} | {4,-20} | {5,5} |", Theme, Level, Author, QuestionText, Answer, Points);
        }
        /// <summary>
        /// formats data to csv string
        /// </summary>
        /// <returns>returns csv formatted data</returns>
        public virtual string ToCSVString()
        {
            return String.Format("{0};{1};{2};{3};{4};{5};", Theme, Level, Author, QuestionText, Answer, Points);
        }
        /// <summary>
        /// stores properties in list of string
        /// </summary>
        /// <returns>list of properties</returns>
        public virtual List<string> GetProperties()
        {
            return new List<string> { Theme, Level, Author, QuestionText, Answer, Points.ToString() };
        }
        /// <summary>
        /// implements IComparable
        /// </summary>
        /// <param name="question">other question</param>
        /// <returns>returns child class result</returns>
        public abstract int CompareTo(Question question);

        /// <summary>
        /// implements IEquatable, compares by author and questiontext
        /// </summary>
        /// <param name="other">other question</param>
        /// <returns>bool value based on comparison</returns>
        public bool Equals(Question other)
        {
            return this.Author == other.Author && this.QuestionText == other.QuestionText;
        }
    }
}
