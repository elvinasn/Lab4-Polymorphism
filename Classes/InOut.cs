using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Lab4.Classes
{
    /// <summary>
    /// static class to store in and out operations
    /// </summary>
    public static class InOut
    {
        /// <summary>
        /// reads data to list of questionsregister
        /// </summary>
        /// <param name="dir">name of directory</param>
        /// <returns>list of question registers</returns>
        public static List<QuestionsRegister> ReadRegisters(string dir, Label error)
        {
            List<QuestionsRegister> registers = new List<QuestionsRegister>();
            foreach (string txtName in Directory.GetFiles(dir, "*.txt"))
            {
                string[] lines = File.ReadAllLines(txtName, Encoding.UTF8);
                QuestionsRegister register = new QuestionsRegister(lines[0]);
                try
                {
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] values = lines[i].Split(',');
                        string theme = values[0];
                        string level = values[1];
                        string author = values[2];
                        string question = values[3];
                        string answer = values[4];
                        int points = Convert.ToInt32(values[5]);
                        if (values.Length == 7)
                        {
                            string file = values[6];
                            MusicQuestion quest = new MusicQuestion(theme, level, author, question, answer, points, file);
                            register.Add(quest);
                        }
                        else
                        {
                            List<string> answers = new List<string>();
                            for (int j = 6; j < values.Length; j++)
                            {
                                answers.Add(values[j]);
                            }
                            TestQuestion quest = new TestQuestion(theme, level, author, question, answer, points, answers);
                            register.Add(quest);
                        }

                    }
                }
                catch
                {
                    error.Text = string.Format("Wrong data in file {0} ", txtName);
                }
                
                registers.Add(register);
            }
            return registers;
        }


        /// <summary>
        /// prints given question register to txt file
        /// </summary>
        /// <param name="fileName">txt file to print in</param>
        /// <param name="register">register to prin</param>
        public static void PrintQuestRegister(string fileName, QuestionsRegister register, Label error2)
        {
            string[] lines = new string[register.Count() + (register.Count() > 0 ? 6 : 3)];
            string tableHeader = string.Format("| {0,-20} | {1,-12} | {2,-8} |" +
                      " {3,-55} | {4,-20} | {5,-5} | {6,-13} | {7,-48} |", "Tema",
                      "Sudetingumas", "Autorius", "Klausimas", "Teisingas atsakymas",
                      "Balai", "Failo pav.", "Ats. variantai");
            string dashes = new string('-', tableHeader.Length);
            try
            {
                lines[0] = register.TeamName + " klausimai:";
                if(register.Count() > 0)
                {
                    lines[1] = dashes;
                    lines[2] = tableHeader;
                    lines[3] = dashes;
                    int i = 4;
                    foreach (Question current in register)
                    {
                        lines[i] = current.ToString();
                        i++;
                    }
                    lines[lines.Length - 2] = dashes;

                }
                else
                {
                    lines[1] = "Sąrašas tuščias";
                }
                lines[lines.Length - 1] = string.Empty;
            }
            catch (IndexOutOfRangeException ex)
            {
                error2.Text = string.Format("Index is not in the array boundaries in method {0}. Sorry for the mistake!", ex.TargetSite);
            }
            
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
        

        /// <summary>
        /// prints given register to csv
        /// </summary>
        /// <param name="fileName">filename to print in</param>
        /// <param name="register">register to print</param>
        /// <param name="skipHeader">default is false, true if u wwant to skip header</param>
        public static void PrintQuestRegisterCSV(string fileName, QuestionsRegister register, bool skipHeader = false)
        {
            List<string> lines = new List<string>();
            lines.Add(register.TeamName + " klausimai:");
            
 
            if(register.Count() > 0)
            {
                lines.Add(string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", "Tema",
                     "Sudetingumas", "Autorius", "Klausimas", "Teisingas atsakymas",
                     "Balai", "Failo pav.", "Ats. variantai"));
                try
                {
                    for (int i = 0; i < register.Count(); i++)
                        lines.Add(register.GetByIndex(i).ToCSVString());
                    if (skipHeader)
                        lines.RemoveAt(1);
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new Exception(string.Format("Index is not in the array boundaries in method {0}", ex.TargetSite));
                }
            }
            else
            {
                lines.Add("Sąrašas tuščias");
            }
           

            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// prints best authors to txt
        /// </summary>
        /// <param name="fileName">filename to print in</param>
        /// <param name="authors">authors to print</param>
        /// <param name="header">header of the table</param>
        public static void PrintBestAuthors(string fileName, List<Author> authors, string header)
        {
            string[] lines = new string[authors.Count + (authors.Count() > 0 ? 2 : 3)];

            try
            {
                lines[0] = header;
                int i = 1;
                foreach (Author author in authors)
                {
                    lines[i] = author.ToString();
                    i++;
                }
                if (authors.Count() == 0)
                    lines[lines.Length - 2] = "Sąrašas tuščias";
                lines[lines.Length - 1] = string.Empty;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new Exception(string.Format("Index is not in the array boundaries in method {0}", ex.TargetSite));
            }

            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}