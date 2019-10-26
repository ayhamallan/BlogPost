using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DomainModel.Helpers
{
    public class PagedResults<T>
    {
        /// <summary>
        /// The total number of records available.
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// The records this page represents.
        /// </summary>
        public IEnumerable<T> Results { get; set; }
    }
}
