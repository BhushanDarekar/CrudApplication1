namespace CrudApplication1.Models
{
    public class Pager
    {
        public string searchString { get; set; }
        public string sortBy { get; set; } = string.Empty;
        public string sortDirection { get; set; } = string.Empty;
        
        public string Controller { get; set; }
        public string Action { get; set; }


        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public Pager()
        {

        }
        //        public Pager(int totalItems, int page, int pageSize)
        public Pager(int totalItems, int page, int pageSize, string sortBy = "" , string sortDirection = "")
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if(startPage <=0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if(endPage > totalPages)
            {
                endPage = totalPages;
                if(endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }
            TotalItems = totalItems;         
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;

            this.sortBy = sortBy;
            this.sortDirection = sortDirection;

        }
    }

    
}
