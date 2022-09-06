using System;

namespace LibraryWebAPI.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {

            get { return pageSize; }

            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }


                public string Name { get; set; } = string.Empty;
                public string City { get; set; } = string.Empty;
                public string Address { get; set; } = string.Empty;
                public string Email { get; set; } = string.Empty;
                public string Author { get; set; } = string.Empty;
                public int? Quantity { get; set; }
                public DateTime? Launch { get; set; }
                public int? TotalRented { get; set; }
                public DateTime? RentDate { get; set; }
                public DateTime? ForecastDate { get; set; }
                public DateTime? ReturnDate { get; set; }

    }

    }
