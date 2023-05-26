using LibraryApp;
using ProLibrary.Models;
using ProLibrary.Services;
using ProLibrary.Services.Interfaces;
using System;
using System.Windows;

namespace ProLibrary.Windows.LoansWindows
{
    public partial class RemoveLoanWindow : Window
    {
        private readonly ILoanOfBookService _loanService = new LoanOfBookService();

        public RemoveLoanWindow()
        {
            InitializeComponent();
        }

        private async void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(LoanIdTB.Text);

                LoanOfBook readerDb = await _loanService.GetLoanOfBook(id);

                if (readerDb is null)
                {
                    LoanIdTB.Text = string.Empty;
                    MessageBox.Show("Пользователь с таким id отсутствует!");
                    return;
                }

                await _loanService.RemoveLoanOfBook(id);

                MainWindow newWindow = new();
                newWindow.Show();
                this.Close();
            }
            catch (Exception)
            {
                LoanIdTB.Text = string.Empty;

                MessageBox.Show("Проверьте правильность введенных данных." +
                    " Обратите внимание поле для заполнения не должно быть пустым," +
                    " а также должно содержать число.");
            }
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow newWindow = new();
            newWindow.Show();
        }
    }
}

