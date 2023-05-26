using ProLibrary.Services.Interfaces;
using ProLibrary.Services;
using System.Windows;
using ProLibrary.Models;
using System;
using System.Collections.Generic;
using LibraryApp;

namespace ProLibrary.Windows.LoansWindows
{
    public partial class UpdateReaderWindow : Window
    {
        private readonly IReaderService _readerService = new ReaderService();
        private readonly IReaderStatusService _statusService = new ReaderStatusService();

        public UpdateReaderWindow()
        {
            InitializeComponent();
            GenerateComboBox();
        }

        private async void GenerateComboBox() 
        {
            var statuses = await _statusService.GetStatuses();
            List<string> statusesString = new();

            foreach (var status in statuses)
            {
                statusesString.Add(status.StatusName);
            }

            ReaderStatusCB.ItemsSource = statusesString;
        }

        private async void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ReaderIdTB.Text);
                int status = ReaderStatusCB.SelectedIndex;

                Reader readerDb = await _readerService.GetReader(id);

                if (readerDb is null)
                {
                    ReaderIdTB.Text = string.Empty;
                    MessageBox.Show("Пользователь с таким id отсутствует!");
                    return;
                }

                await _readerService.UpdateReader(id, status);
                await _readerService.GetReader(id);

                MainWindow newWindow = new();
                newWindow.Show();
                this.Close();
            }
            catch (Exception)
            {
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
