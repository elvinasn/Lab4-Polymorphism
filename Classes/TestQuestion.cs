using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Classes
{
    /// <summary>
    /// class to store data about test question
    /// </summary>
    public class TestQuestion : Question, IComparable<Question>, IEquatable<Question>
    {
        private string[] Answers { get; set; }

        /// <summary>
        /// constructor with multiple parameters, calls base class constructor
        /// </summary>
        /// <param name="theme">given theme</param>
        /// <param name="level">given level</param>
        /// <param name="author">given author</param>
        /// <param name="questionText">given question text</param>
        /// <param name="answer">given answer</param>
        /// <param name="points">given points</param>
        /// <param name="answers">given answers</param>
        public TestQuestion(string theme, string level, string author, string questionText, string answer, int points,
            List<string> answers) : base(theme, level, author, questionText, answer, points)
        {
            Answers = new string[answers.Count];
            for (int i = 0; i < answers.Count; i++)
                Answers[i] = answers[i];
        }

        /// <summary>
        /// overriden tostring method to return formatted data about TestQuestion
        /// </summary>
        /// <returns>formatted data</returns>
        public override string ToString()
        {
            return base.ToString()+ String.Format(" {0,-13} | {1,-48} |", "-", string.Join(" ", Answers));
        }

        /// <summary>
        /// formats data to csv string
        /// </summary>
        /// <returns>returns csv formatted data</returns>
        public override string ToCSVString()
        {
            return base.ToCSVString() + String.Format("{0};{1};","-", string.Join(" ", Answers));
        }

        /// <summary>
        /// overrides parent class CompareTo method, to compare by theme and level
        /// </summary>
        /// <param name="question">other question</param>
        /// <returns>returns int value based on the comparison</returns>
        public override int CompareTo(Question question)
        {
            int temp = this.Theme.CompareTo(question.Theme);
            if (temp == 0)
                temp = this.Level.CompareTo(question.Level);
            return temp;
        }

                
        /// <summary>
        /// stores properties in list of string
        /// </summary>
        /// <returns>list of properties</returns>
        public override List<string> GetProperties()
        {
            List<string> full = base.GetProperties();
            full.Add("-");

            full.Add(string.Join(" ", Answers));
            return full;
        }

    }
}