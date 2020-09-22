using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIFilms.Models
{
    public class Pagination
    {
        public int MaximumPageSize { get; set; }
        public int NumberPage { get; set; }
        public int PageSize { get; set; }

        [BindNever]
        public int PageOfSize
        {
            get { return PageSize; }
            set
            {
                PageSize = (value > PageOfSize) ? PageOfSize : value;
            }
        }
    }
}