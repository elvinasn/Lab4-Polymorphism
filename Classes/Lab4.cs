using System;
using System.Collections.Generic;
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
        /// <summary>
        /// fills aspx table by register data
        /// </summary>
        /// <param name="register">register to fill the table with</param>
        /// <param name="table">the table</param>
        /// <param name="label">header</param>
        /// <param name="div">container of the table</param>
        /// <param name="empty">label of empty text</param>
        /// <param name="authors">best authors</param>
        /// <param name="LabelAuthor">label for best authors</param>
        public static void FillRegisterTable(QuestionsRegister register, Table table, Label label, Control div, Label empty, List<Author> authors = null, Label LabelAuthor = null)
        {
            HtmlControl control = (HtmlControl)div;
            control.Style.Add("display", "flex");
            label.Text = register.TeamName + " klausimai:";
            if (register.Count() == 0)
                empty.CssClass = empty.CssClass.Replace("none", "");
            else
            {
                List<string> headers = new List<string>{ Bold("Tema"), Bold("Sudetingumas"), Bold("Autorius"), Bold("Klausimas"), Bold("Teisingas atsakymas"),
                     Bold("Balai"), Bold("Failo pav."), Bold("Ats. variantai")};
                table.Rows.Add(CreateRow(headers));
                foreach (Question question in register)
                {
                    table.Rows.Add(CreateRow(question.GetProperties()));
                }
                if (LabelAuthor != null)
                {
                    LabelAuthor.Text = CreateLabelForAuthors(authors, "Geriausi autoriai: ");
                }
            }



        }

        /// <summary>
        /// fills best author container with data
        /// </summary>
        /// <param name="label1">label for best authors</param>
        /// <param name="label2">label for best music questions authors</param>
        /// <param name="bestAuthors">best authors</param>
        /// <param name="bestMusicAuthors">best music question authors</param>
        /// <param name="div">parent element</param>
        public static void FillBestAuthors(Label label1, Label label2, List<Author> bestAuthors, List<Author> bestMusicAuthors, Control div)
        {
            HtmlControl control = (HtmlControl)div;
            control.Style.Add("display", "flex");
            label1.Text = CreateLabelForAuthors(bestAuthors, "Geriausi autoriai visose atstovybėse: ");
            label2.Text = CreateLabelForAuthors(bestMusicAuthors, "Geriausi muzikinių klausimų autoriai visose atstovybėse: ");
        }

        /// <summary>
        /// creates row by Ienumerable string values
        /// </summary>
        /// <param name="values">values of cells</param>
        /// <returns>row of the table</returns>
        protected static TableRow CreateRow(IEnumerable<string> values)
        {
            TableRow row = new TableRow();
            foreach (string value in values)
            {
                row.Cells.Add(CreateCell(value));
            }
            return row;

        }

        /// <summary>
        /// creates a table cell with given string value
        /// </summary>
        /// <param name="value">cell text</param>
        /// <returns>new table cell</returns>
        protected static TableCell CreateCell(string value)
        {
            TableCell cell = new TableCell();
            cell.Text = value;
            return cell;
        }

        /// <summary>
        /// bolds given string
        /// </summary>
        /// <param name="str">string to bold</param>
        /// <returns>bold text</returns>
        protected static string Bold(string str)
        {
            return string.Format("<b>{0}</b>", str);
        }

        /// <summary>
        /// creates label text for authors
        /// </summary>
        /// <param name="authors">given authors</param>
        /// <param name="header">header of label</param>
        /// <returns>text of the label</returns>
        protected static string CreateLabelForAuthors(List<Author> authors, string header)
        {
            string text = header;
            foreach (Author author in authors)
            {
                text = text + author.ToString().TrimEnd('.') + ", ";
            }
            text = text.Substring(0, text.Length - 2);
            return text;
        }
    }
}