using Microsoft.Win32;
using praktika15.Classes;
using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace praktika15.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        DocumentContext Document;
        string s_src = "";
        public Add(DocumentContext documentContext = null)
        {
            InitializeComponent();
            if (documentContext != null )
            {
                Document = documentContext;

                if(File.Exists(documentContext.Src))
                    src.Source = new BitmapImage(new System.Uri(documentContext.Src));
                
                tbName.Text = documentContext.Name;
                tbUser.Text = documentContext.User;
                tbCode.Text = documentContext.IdDocument.ToString();
                tbDate.Text = documentContext.Date.ToString("dd.MM.yyyy");
                tbStatus.SelectedIndex = documentContext.Status;
                tbDirection.Text = documentContext.Direction;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Main());
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "PNG (*.png)|*.png|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                src.Source = new BitmapImage(new System.Uri(ofd.FileName));
                s_src = ofd.FileName;
            }
        }

        private void AddDocument(object sender, RoutedEventArgs e)
        {
            if (s_src.Length == 0)
            {
                MessageBox.Show("Необходимо выбрать изображение");
                return;
            }
            if (tbName.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать наименование");
                return;
            }
            if (tbUser.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать ответственного");
                return;
            }
            if (tbCode.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать код документа");
                return;
            }
            if (tbDate.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать дату поступления");
                return;
            }
            if (tbStatus.SelectedIndex != -1)
            {
                MessageBox.Show("Необходимо выбрать статус документа");
                return;
            }
            if (tbDirection.Text.Length == 0)
            {
                MessageBox.Show("Необходимо указать направление");
                return;
            }
            if (Document == null)
            {
                Document = new DocumentContext()
                {
                    Src = s_src,
                    Name = tbName.Text,
                    IdDocument = Convert.ToInt32(tbCode.Text),
                    Date = DateTime.Parse(tbDate.Text),
                    Status = tbStatus.SelectedIndex,
                    Direction = tbDirection.Text
                };
                Document.Save();
                MessageBox.Show("Документ добавлен");
            }
            else
            {
                Document.Src = s_src;
                Document.Name = tbName.Text;
                Document.IdDocument = Convert.ToInt32(tbCode.Text);
                Document.Date = DateTime.Parse(tbDate.Text);
                Document.Status = tbStatus.SelectedIndex;
                Document.Direction = tbDirection.Text;
                Document.Save();
                MessageBox.Show("Документ изменён");
            }
            MainWindow.init.AllDocuments = new DocumentContext().AllDocuments();
            MainWindow.init.frame.Navigate(new Main());
        }
    }
}
