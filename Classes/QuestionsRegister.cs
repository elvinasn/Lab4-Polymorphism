using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Classes
{
    /// <summary>
    /// register for questions
    /// </summary>
    public class QuestionsRegister : IEnumerable<Question>
    {
        private List<Question> Questions;
        public string TeamName { get; set; }

        /// <summary>
        /// constructor without parameters
        /// </summary>
        public QuestionsRegister()
        {
            Questions = new List<Question>();
        }

        /// <summary>
        /// constructor with teamName parameter
        /// </summary>
        /// <param name="teamName">given name of the team</param>
        public QuestionsRegister(string teamName) : this()
        {
            TeamName = teamName;
        }

        /// <summary>
        /// constructor with multiple parameters
        /// </summary>
        /// <param name="teamName">given name of the team</param>
        /// <param name="questions">given list of questions</param>
        public QuestionsRegister(string teamName, List<Question> questions) : this(teamName)
        {
            foreach (Question question in questions)
                Questions.Add(question);
        }
        
        /// <summary>
        /// adds given question to the register
        /// </summary>
        /// <param name="question">given question to add</param>
        public void Add(Question question) => Questions.Add(question);

        /// <summary>
        /// gets question from register by index
        /// </summary>
        /// <param name="index">given index</param>
        /// <returns>question by index</returns>
        public Question GetByIndex(int index)
        {
            if (index >= 0)
            {
                return Questions[index];
            }
            else
            {
                return null;
            }
        }
        public int Count() => Questions.Count;



        /// <summary>
        /// filters authors from question register with their questions count
        /// </summary>
        /// <returns>returns author lists with their question counts in the register</returns>
        public List<Author> AuthorList()
        {
            List<Author> authors = new List<Author>();
            foreach(Question curr in Questions)
            {
                Author auth = new Author(curr.Author);
                if (!authors.Contains(auth))
                    authors.Add(auth);
                else
                    authors[authors.IndexOf(auth)].Count++;
            }
            return authors;
        }

        /// <summary>
        /// filters question register by given type
        /// </summary>
        /// <param name="type">given type</param>
        /// <returns>filtered register</returns>
        public QuestionsRegister FilterType(string type)
        {
            QuestionsRegister filtered = new QuestionsRegister(TeamName);

            foreach (Question current in Questions)
            {
                string currentType = current.GetType().Name;
                if (type == currentType)
                    filtered.Add(current);

            }

            return filtered;
        }

        /// <summary>
        /// filters register by theme and returns list of them
        /// </summary>
        /// <param name="theme">given theme</param>
        /// <returns>returns filtered list</returns>
        public List<Question> FilterByTheme(string theme)
        {
            List<Question> filtered = new List<Question>();
            foreach (Question current in Questions)
            {
                if (theme.ToLower() == current.Theme.ToLower())
                    filtered.Add(current);

            }
            return filtered;
        }

        /// <summary>
        /// sorts the register
        /// </summary>
        public void Sort()
        {
            bool sorted = false;
            try
            {
                while (!sorted)
                {
                    sorted = true;
                    for (int i = 0; i < Count() - 1; i++)
                    {
                        Question a = this.Questions[i];
                        Question b = this.Questions[i + 1];
                        if (a.CompareTo(b) > 0)
                        {
                            sorted = false;
                            Questions[i] = b;
                            Questions[i + 1] = a;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("{0} in method{1}", ex.Message, ex.TargetSite));
            }
            
        }


        public IEnumerator<Question> GetEnumerator()
        {
            foreach (Question q in Questions)
                yield return q;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


    }
}