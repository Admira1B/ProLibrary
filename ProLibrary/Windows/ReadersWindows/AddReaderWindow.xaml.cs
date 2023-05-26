using ProLibrary.Models;
using ProLibrary.Services;
using ProLibrary.Services.Interfaces;
using System;
using System.Windows;

namespace ProLibrary.Windows.ReadersWindows
{
    public partial class AddReaderWindow : Window
    {
        private readonly IReaderService _readerService = new ReaderService();

        public AddReaderWindow()
        {
            InitializeComponent();
        }

        private async void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reader newReader = new()
                {
                    FirstName = FirstNameTB.Text,
                    LastName = LastNameTB.Text,
                    Address = AddressTB.Text,
                    TelephoneNumber = TelephoneTB.Text,
                    ReaderStatusId = 0
                };

                await _readerService.AddReader(newReader);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность введенных данных." +
                    " Обратите внимание поля для заполнения не должны быть пустыми.");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
