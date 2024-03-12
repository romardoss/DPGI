using Microsoft.Win32;
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

namespace lab2._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, Execute_Save, CanExecute_Save);
            CommandBindings.Add(saveCommand);

            CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open, Execute_Open, CanExecute_Open);
            CommandBindings.Add(openCommand);

            CommandBinding clearCommand = new CommandBinding(ApplicationCommands.Delete, Execute_Clear, CanExecute_Clear);
            CommandBindings.Add(clearCommand);

            /*CommandBinding copyCommand = new CommandBinding(ApplicationCommands.Copy, Execute_Copy, CanExecute_Copy);
            CommandBindings.Add(copyCommand);

            CommandBinding pasteCommand = new CommandBinding(ApplicationCommands.Paste, Execute_Paste, CanExecute_Paste);
            CommandBindings.Add(pasteCommand);*/
        }

        public void CanExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = textField.Text.Trim().Length > 0;
        }

        public void Execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/myFile.txt";
            System.IO.File.WriteAllText(path, textField.Text);
            MessageBox.Show("The file was saved in myFile.txt in Documents folder!");
        }

        public void CanExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = textField.Text.Trim().Length == 0;
        }

        public void Execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            FileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            openFileDialog.ShowDialog();
            string input = System.IO.File.ReadAllText(openFileDialog.FileName);
            textField.Text = input.ToString();
        }

        public void CanExecute_Clear(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = textField.Text.Trim().Length > 0;
        }

        public void Execute_Clear(object sender, ExecutedRoutedEventArgs e)
        {
            textField.Text = string.Empty;
        }

        /*public void CanExecute_Copy(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = textField.Text.Trim().Length > 0;
        }

        public void Execute_Copy(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(textField.Text);
            MessageBox.Show("Текст скопійовано в буфер обміну");
        }

        public void CanExecute_Paste(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
        }

        public void Execute_Paste(object sender, ExecutedRoutedEventArgs e)
        {
            textField.Text += "\n";
            textField.Text += Clipboard.GetText();
        }*/
    }
}
