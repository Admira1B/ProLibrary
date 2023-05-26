using ProLibrary.Services.Interfaces;
using ProLibrary.Services;
using System;
using System.Windows;
using ProLibrary.Models;

namespace ProLibrary.Windows.LoansWindows
{
    public partial class RemoveReaderWindow : Window
    {
        private readonly IReaderService _readerService = new ReaderService();

        public RemoveReaderWindow()
        {
            InitializeComponent();
        }

        private async void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ReaderIdTB.Text);

                Reader readerDb = await _readerService.GetReader(id);

                if (readerDb is null)
                {
                    ReaderIdTB.Text = string.Empty;
                    MessageBox.Show("Пользователь с таким id отсутствует!");
                    return;
                }

                await _readerService.RemoveReader(id);

                this.Close();
            }
            catch (Exception exeption)
            {
                ReaderIdTB.Text = string.Empty;

                MessageBox.Show("Проверьте правильность введенных данных." +
                    " Обратите внимание поле для заполнения не должно быть пустым," +
                    " а также должно содержать число.");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
