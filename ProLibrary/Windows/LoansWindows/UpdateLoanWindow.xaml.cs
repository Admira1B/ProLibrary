using ProLibrary.Models;
using ProLibrary.Services.Interfaces;
using ProLibrary.Services;
using System;
using System.Windows;
using LibraryApp;

namespace ProLibrary.Windows.LoansWindows
{
    public partial class UpdateLoanWindow : Window
    {
        private readonly ILoanOfBookService _loanService = new LoanOfBookService();

        public UpdateLoanWindow()
        {
            InitializeComponent();
        }

        private async void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(LoanIdTB.Text);
                DateTimeOffset datenow = DateTimeOffset.Now;

               LoanOfBook loanDb = await _loanService.GetLoanOfBook(id);

                if (loanDb is null)
                {
                    LoanIdTB.Text = string.Empty;
                    MessageBox.Show("Запись о заимствовании книги с таким id отсутствует!");
                    return;
                }

                await _loanService.UpdateLoanOfBook(id, datenow);

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