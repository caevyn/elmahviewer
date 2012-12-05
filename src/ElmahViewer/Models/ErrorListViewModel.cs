using System;
using System.Collections.Generic;

namespace ElmahViewer.Models
{
    public class ErrorListViewModel
    {
        public ApplicationListModel AllApplications { get; set; }
        public int Count { get; set; }
        public IList<ErrorModel> Errors { get; set; }
        public string ApplicationName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int FirstErrorNumber
        {
            get
            {
                return PageIndex*PageSize + 1;
            }
        }
        public int LastErrorNumber
        {
            get
            {
                return FirstErrorNumber + Errors.Count -1;
            }
        }
        public int TotalPages
        {
            get
            {
                return (int) Math.Ceiling((double) Count/PageSize);
            }
        }
        public bool HasMorePages
        {
            get
            {
                return (PageIndex + 1) * PageSize < Count;
            }
        }
        public int[] Sizes
        {
            get { return new[] { 10, 15, 20, 25, 30, 50, 100 }; }
        }
    }
}