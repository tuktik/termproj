using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Leditor
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
       bool SaveState=true;
        
        public MainWindow()
        {
            InitializeComponent();
            Paragraph p = TextBox.Document.Blocks.FirstBlock as Paragraph;
            p.Margin = new System.Windows.Thickness(0);
        }

        private void newfile(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "변경 사항을 저장하시겠습니까?";
            string caption = "lee editor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Question;
            if (true)
            {
                MessageBoxResult result =  MessageBox.Show(messageBoxText, caption, button, icon);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        filesave();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            }

            TextBox.Document.Blocks.Clear();
        }

        private void Hfileopen(object sender, RoutedEventArgs e)
        {
            fileopen();
        }
        private void fileopen()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text File (*.txt)|*.txt | C Files (*.c)|*.c | CPP Files (*.cpp)|*.cpp | JAVA Files (*.java)|*.java";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                this.Title = filename;
            }
        }

        private void Hfilesave(object sender, RoutedEventArgs e)
        {
            filesave();
        }

        private void filesave()
        {
            
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text File (*.txt)|*.txt | C Files (*.c)|*.c | CPP Files (*.cpp)|*.cpp | JAVA Files (*.java)|*.java"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //File.WriteAllText(dialog.FileName, fileText);
            }
        }

        private void HSetLineNumber(object sender, RoutedEventArgs e)
        {
            SetLineNumber();
        }
        private void SetLineNumber()
        {
            int offset = 0;
            if(LineNum.IsChecked==true)
            {
                TextBox.CaretPosition.GetOffsetToPosition(TextBox.Document.ContentStart);
                TextBox.CaretPosition.GetPositionAtOffset(offset).GetCharacterRect(LogicalDirection.Forward);
            }
            else
            {

            }
        }

    }
}
