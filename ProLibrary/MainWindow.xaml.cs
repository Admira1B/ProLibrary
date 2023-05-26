using System.Windows;
using ProLibrary.Services.Interfaces;
using ProLibrary.Services;
using ProLibrary;
using ProLibrary.Windows.ReadersWindows;
using ProLibrary.Windows.LoansWindows;

namespace LibraryApp
{
    public partial class MainWindow : Window
    {
        private readonly IBookService _bookService = new BookService();
        private readonly IReaderService _readerService= new ReaderService();
        private readonly ILoanOfBookService _loanService = new LoanOfBookService();

        private PageStatus.Status status = PageStatus.CurrentStatus;

        public MainWindow()
        {
            InitializeComponent();
            ShowPageElements();
        }

        private void LoadForm()
        {
            switch (status)
            {
                case PageStatus.Status.Book:
                    LoadBooks();
                    break;
                case PageStatus.Status.Reader:
                    LoadReaders();
                    break;
                case PageStatus.Status.Loan:
                    LoadLoans();
                    break;
            }
            return;
        }

        private void ShowPageElements()
        {
            switch (status)
            {
                case PageStatus.Status.Book:
                    booksList.Visibility = Visibility.Visible;
                    readerList.Visibility = Visibility.Collapsed;
                    loansList.Visibility = Visibility.Collapsed;

                    LineElement.Visibility = Visibility.Collapsed;

                    AddReaderBtn.Visibility = Visibility.Collapsed;
                    RemoveReaderBtn.Visibility = Visibility.Collapsed;
                    UpdateReaderBtn.Visibility = Visibility.Collapsed;

                    AddLoanBtn.Visibility = Visibility.Collapsed;
                    RemoveLoanBtn.Visibility = Visibility.Collapsed;
                    UpdateLoanBtn.Visibility = Visibility.Collapsed;

                    LoadBooks();

                    break;

                case PageStatus.Status.Reader:
                    booksList.Visibility = Visibility.Collapsed;
                    readerList.Visibility = Visibility.Visible;
                    loansList.Visibility = Visibility.Collapsed;

                    LineElement.Visibility = Visibility.Visible;

                    AddReaderBtn.Visibility = Visibility.Visible;
                    RemoveReaderBtn.Visibility = Visibility.Visible;
                    UpdateReaderBtn.Visibility = Visibility.Visible;

                    AddLoanBtn.Visibility = Visibility.Collapsed;
                    RemoveLoanBtn.Visibility = Visibility.Collapsed;
                    UpdateLoanBtn.Visibility = Visibility.Collapsed;

                    LoadReaders();

                    break;

                case PageStatus.Status.Loan:
                    booksList.Visibility = Visibility.Collapsed;
                    readerList.Visibility = Visibility.Collapsed;
                    loansList.Visibility = Visibility.Visible;

                    LineElement.Visibility = Visibility.Visible;

                    AddReaderBtn.Visibility = Visibility.Collapsed;
                    RemoveReaderBtn.Visibility = Visibility.Collapsed;
                    UpdateReaderBtn.Visibility = Visibility.Collapsed;

                    AddLoanBtn.Visibility = Visibility.Visible;
                    RemoveLoanBtn.Visibility = Visibility.Visible;
                    UpdateLoanBtn.Visibility = Visibility.Visible;

                    LoadLoans();

                    break;
            }
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            string filter = searchBox.Text;

            if (string.IsNullOrEmpty(filter))
            {
                LoadForm();
                return;
            }

            switch (status)
            {
                case PageStatus.Status.Book:
                    booksList.ItemsSource = await _bookService.GetFiltredBooks(filter);
                    break;
                case PageStatus.Status.Reader:
                    readerList.ItemsSource = await _readerService.GetFiltredReaders(filter);
                    break;
                case PageStatus.Status.Loan:
                    loansList.ItemsSource = await _loanService.GetFiltredLoans(filter);
                    break;
            }
        }

        #region DataLoadsToListView
        private async void LoadBooks()
        {
            booksList.ItemsSource = await _bookService.GetBooks();
        }

        private async void LoadReaders() 
        {
            readerList.ItemsSource = await _readerService.GetReaders();
        }

        private async void LoadLoans()
        {
            loansList.ItemsSource = await _loanService.GetLoanOfBooks();
        }
        #endregion

        #region ShowListsBtnClicks
        private void BooksBtn_Click(object sender, RoutedEventArgs e)
        {
            PageStatus.CurrentStatus = PageStatus.Status.Book;
            status = PageStatus.CurrentStatus;

            ShowPageElements();
        }

        private void ReadersBtn_Click(object sender, RoutedEventArgs e)
        {
            PageStatus.CurrentStatus = PageStatus.Status.Reader;
            status = PageStatus.CurrentStatus;

            ShowPageElements();
        }

        private void LoansBtn_Click(object sender, RoutedEventArgs e)
        {
            PageStatus.CurrentStatus = PageStatus.Status.Loan;
            status = PageStatus.CurrentStatus;

            ShowPageElements();
        }
        #endregion

        #region ReaderMethods
        private void AddReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddReaderWindow newWindow = new();
            newWindow.ShowDialog();
            LoadReaders();
        }

        private void RemoveReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            RemoveReaderWindow newWindow = new();
            newWindow.ShowDialog();
            LoadReaders();
        }

        private void UpdateReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateReaderWindow newWindow = new();
            newWindow.ShowDialog();
            this.Close();
        }
        #endregion

        #region LoanMethods
        private void AddLoanBtn_Click(object sender, RoutedEventArgs e)
        {
            AddLoanWindow newWindow = new();
            newWindow.ShowDialog();
            this.Close();
        }

        private void RemoveLoanBtn_Click(object sender, RoutedEventArgs e)
        {
            RemoveLoanWindow newWindow = new();
            newWindow.ShowDialog();
            LoadLoans();
        }

        private void UpdateLoanBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateLoanWindow newWindow = new();
            newWindow.ShowDialog();
            this.Close();
        }
        #endregion
    }
}