using ProLibrary.Models;
using ProLibrary.Services;
using ProLibrary.Services.Interfaces;
using System;
using System.Windows;

namespace ProLibrary.Windows.LoansWindows
{
    public partial class AddLoanWindow : Window
    {
        private readonly ILoanOfBookService _loanService = new LoanOfBookService();

        public AddLoanWindow()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoanOfBook newLoan = new()
                {
                    ReaderId = Convert.ToInt32(ReaderIdTB.Text),
                    BookId = Convert.ToInt32(BookIdTB.Text),
                    CreationDate = (DateTimeOffset.Now).ToString().Substring(0, 10),
                    ReturningDate = "Не возвращено",
                };

                await _loanService.AddLoanOfBook(newLoan);
                this.Close();
            }
            catch (Exception)
            {
                BookIdTB.Text = string.Empty;
                ReaderIdTB.Text = string.Empty;

                MessageBox.Show("Проверьте правильность введенных данных." +
                    " Обратите внимание поля для заполнения не должны быть пустыми.");
            }
        }
    }
}
