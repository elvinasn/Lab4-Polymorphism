using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Lab4.Classes;

namespace Lab4
{
    public partial class Lab4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo di1 = new DirectoryInfo(Server.MapPath("App_Data/Data/"));

            foreach (FileInfo file in di1.GetFiles())
            {
                file.Delete();
            }
          
            System.IO.DirectoryInfo di2 = new DirectoryInfo(Server.MapPath("App_Data/Results/"));

            foreach (FileInfo file in di2.GetFiles())
            {
                file.Delete();
            }
    

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Table> tables = new List<Table> { Table1, Table2, Table3, Table4 };
            List<Label> labels = new List<Label> { Label1, Label2, Label3, Label4 };
            List<Control> divs = new List<Control> { FindControl("div1"), FindControl("div2"), FindControl("div3"), FindControl("div4") };
            List<Label> empty = new List<Label> { Nera1, Nera2, Nera3, Nera4 };
            List<Label> authors = new List<Label> { Autoriai1, Autoriai2, Autoriai3, Autoriai4 };
            if (FileUpload1.HasFile)
            {
                
                string pathToDir = Server.MapPath("App_Data/Data/");
                string pathToRes = Server.MapPath("App_Data/Results/");

                List<Author> authorsAll = new List<Author>();
                List<Author> musicQuestionAuthorsAll = new List<Author>();

                string file = Path.GetExtension(FileUpload1.FileName);
                if(file == ".txt")
                {
                    Tasks.SaveFiles(FileUpload1, pathToDir);
                }
                List<QuestionsRegister> AllRegisters = InOut.ReadRegisters(pathToDir, error1);



                // TASK 1
                Tasks.BestAuthors(pathToRes, AllRegisters, ref authorsAll, ref musicQuestionAuthorsAll, tables, labels, divs, empty, authors, error2);
                // TASK 2
                int largestCountAll = Tasks.LargestCount(authorsAll);

                List<Author> bestAuthorsAll = Tasks.FilterBestAuthors(authorsAll, largestCountAll);
                InOut.PrintBestAuthors(pathToRes + "rezultatai" + ".txt", bestAuthorsAll,
                        "Geriausi autoriai visose atstovybėse bendrai: ");

                int largestMusicCountAll = Tasks.LargestCount(musicQuestionAuthorsAll);
                List<Author> bestMusicAuthorsAll = Tasks.FilterBestAuthors(musicQuestionAuthorsAll, largestMusicCountAll);
                InOut.PrintBestAuthors(pathToRes + "rezultatai" + ".txt", bestMusicAuthorsAll,
                        "Geriausi musikos klausimu autoriai visose atstovybėse bendrai: ");

                FillBestAuthors(BestAuthors, BestMusicAuthors, bestAuthorsAll, bestMusicAuthorsAll, FindControl("div8"));


                // TASK 3
                List<QuestionsRegister> musicAndTest = Tasks.AllQuestionsByType(AllRegisters);

                musicAndTest[0].Sort();
                musicAndTest[1].Sort();


                InOut.PrintQuestRegisterCSV(pathToRes + "Klausimai.csv", musicAndTest[0]);
                FillRegisterTable(musicAndTest[0], SortedTable1, Label5, FindControl("div5"), Nera5);
                InOut.PrintQuestRegisterCSV(pathToRes + "Klausimai.csv", musicAndTest[1], true);
                FillRegisterTable(musicAndTest[1], SortedTable2, Label6, FindControl("div6"), Nera6);





                // TASK 4
                List<Question> AllByThemeList = Tasks.AllByTheme(AllRegisters, "Istorinis");
                QuestionsRegister AllByThemeRegister = new QuestionsRegister("Istorinis", AllByThemeList);
                InOut.PrintQuestRegisterCSV(pathToRes + "Istorinis.csv", AllByThemeRegister);
                FillRegisterTable(AllByThemeRegister, FilteredTable, Label7, FindControl("div7"), Nera7);

              


            }
        }
    }
}