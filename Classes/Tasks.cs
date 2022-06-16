using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4.Classes
{
    public static class Tasks
    {
        /// <summary>
        /// saves files to given path from fileupload object
        /// </summary>
        /// <param name="FileUpload1">given fileupload</param>
        /// <param name="path">path to dir</param>
        public static void SaveFiles(FileUpload FileUpload1, string path)
        {
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(path + fileName);
            }
        }
        
        /// <summary>
        /// finds largest author count in author list
        /// </summary>
        /// <param name="authors">given authors</param>
        /// <returns>largest count of questions</returns>
        public static int LargestCount(List<Author> authors)
        {
            if(authors.Count > 0)
            {
                Author bestAuth = authors[0];
                for (int i = 0; i < authors.Count; i++)
                {
                    if (authors[i].CompareTo(bestAuth) > 0)
                        bestAuth = authors[i];
                }
                return bestAuth.Count;
            }
            return -1;

        }

        /// <summary>
        /// filters best authors from the list by given int of count
        /// </summary>
        /// <param name="filterFrom">list to filter from</param>
        /// <param name="largestCount">int to filter by</param>
        /// <returns>filtered list</returns>
        public static List<Author> FilterBestAuthors(List<Author> filterFrom, int largestCount)
        {

            List<Author> filtered = new List<Author>();
            foreach (Author auth in filterFrom)
                if (auth.Count == largestCount)
                    filtered.Add(auth);
            return filtered;
        }

        /// <summary>
        /// Does the 1st task, finds best authors in each QuestionRegister and prints it to txt and form.
        /// </summary>
        /// <param name="path">path to dir</param>
        /// <param name="allRegisters">given registers to print</param>
        /// <param name="authorsAll">all authors</param>
        /// <param name="musicQuestionAuthorsAll">all nusic authors</param>
        /// <param name="tables">tables in form for the register</param>
        /// <param name="labels">labels in form for the register</param>
        /// <param name="divs">divs in form for the register</param>
        /// <param name="empty">empty labels in form for the register</param>
        /// <param name="authors">author labels in form for the register</param>
        public static void BestAuthors(string path, List<QuestionsRegister> allRegisters,
            ref List<Author> authorsAll, ref List<Author> musicQuestionAuthorsAll, List<Table> tables,
            List<Label> labels, List<Control> divs, List<Label> empty, List<Label> authors, Label error2)
        {
            try
            {
                for (int i = 0; i < allRegisters.Count(); i++)
                {

                    QuestionsRegister register = allRegisters[i];
                    InOut.PrintQuestRegister(path + "pradiniaiDuom" + ".txt", register, error2);

                    List<Author> allAuthors = register.AuthorList();
                    int largestCount = Tasks.LargestCount(allAuthors);
                    List<Author> bestAuthors = Tasks.FilterBestAuthors(allAuthors, largestCount);

                    InOut.PrintBestAuthors(path + "rezultatai" + ".txt", bestAuthors,
                           "Geriausi autoriai " + register.TeamName + " atstovybėje:");
                    authorsAll.AddRange(bestAuthors);
                    QuestionsRegister musicQuestions = register.FilterType("MusicQuestion");
                    List<Author> musicAuthors = musicQuestions.AuthorList();
                    musicQuestionAuthorsAll.AddRange(musicAuthors);
                    Lab4.FillRegisterTable(register, tables[i], labels[i], divs[i], empty[i], bestAuthors, authors[i]);
                }
            }
            catch
            {
                throw new Exception("Too many data files! Max: 4 files!");
            }
            
        }

        /// <summary>
        /// filters Questions Registers by given theme
        /// </summary>
        /// <param name="allRegisters">registers to filter from</param>
        /// <param name="theme"> given theme</param>
        /// <returns>list of questions of that theme</returns>
        public static List<Question> AllByTheme(List<QuestionsRegister> allRegisters, string theme)
        {
            List < Question > filtered = new List<Question>();
            foreach (QuestionsRegister register in allRegisters)
            {
                filtered.AddRange(register.FilterByTheme(theme));

            }
            return filtered;
        }

        /// <summary>
        /// filters all questions to two types - music and test
        /// </summary>
        /// <param name="registers">registers to filter from</param>
        /// <returns>list of question register, first  one is music questions, other is test questions</returns>
        public static List<QuestionsRegister> AllQuestionsByType(List<QuestionsRegister> registers)
        {
            List<Question> music = new List<Question>();
            List<Question> test = new List<Question>();

            foreach (QuestionsRegister register in registers)
            {
                foreach (Question question in register)
                    if (question.GetType().Name == "MusicQuestion")
                    {
                        music.Add(question);

                    }
                    else
                    {
                        test.Add(question);
                    }
            }
            QuestionsRegister musicReg = new QuestionsRegister("Muzikiniai", music);
            QuestionsRegister testReg = new QuestionsRegister("Testiniai", test);
            List<QuestionsRegister> both = new List<QuestionsRegister>();
            both.Add(musicReg);
            both.Add(testReg);
            return both;

        }

    }
}