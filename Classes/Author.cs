using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Classes
{
    /// <summary>
    /// data class to store info about author
    /// </summary>
    public class Author : IComparable<Author>, IEquatable<Author>
    {
        public string Name { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="count"></param>
        public Author(string name, int count = 1)
        {
            Name = name;
            Count = count;
        }

        /// <summary>
        /// implements IEquatable to compare by names
        /// </summary>
        /// <param name="auth">other author</param>
        /// <returns>return boolean value by their name comparisons</returns>
        public bool Equals(Author auth)
        {
            return Name == auth.Name;
        }

        /// <summary>
        /// overriden gethash code
        /// </summary>
        /// <returns>new hashcode</returns>
        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }


        /// <summary>
        /// overriden tostring method to return formatted data of object
        /// </summary>
        /// <returns>formatted data of object</returns>
        public override string ToString()
        {
            return string.Format("{0} = {1} klausimai.", Name, Count);
        }

        /// <summary>
        /// implements IComparable to compare by count
        /// </summary>
        /// <param name="other">other author</param>
        /// <returns>returns CompareTo int value > 0, if count is bigger, 0 if equals, < 0 if less </returns>
        public int CompareTo(Author other)
        {
            return this.Count.CompareTo(other.Count);
        }
    }
}