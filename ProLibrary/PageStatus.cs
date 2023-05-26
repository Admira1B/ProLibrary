namespace ProLibrary
{
    public static class PageStatus
    {
        public enum Status
        {
            Book,
            Reader,
            Loan
        }

        public static Status CurrentStatus { get; set; } = Status.Book;
    }
}
