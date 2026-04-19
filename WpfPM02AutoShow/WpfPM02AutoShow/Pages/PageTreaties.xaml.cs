using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace WpfPM02AutoShow.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTreaties.xaml
    /// </summary>
    public partial class PageTreaties : Page
    {
        public PageTreaties()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AutoShowBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = AutoShowBDEntities.GetContext().Договоры.ToList();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ManagerAS.MainFrame.Navigate(new AddPageTreaties(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var BluForRemoving = DGrid.SelectedItems.Cast<Договоры>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {BluForRemoving.Count()} элементов ?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

            {
                try
                {
                    AutoShowBDEntities.GetContext().Договоры.RemoveRange(BluForRemoving);
                    AutoShowBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid.ItemsSource = AutoShowBDEntities.GetContext().Договоры.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ManagerAS.MainFrame.Navigate(new AddPageTreaties((sender as Button).DataContext as Договоры));
        }

        
        

        private void BtnXpert_Click(object sender, RoutedEventArgs e)
        {
            DGrid.SelectAllCells();
            DGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, DGrid);
            DGrid.UnselectAllCells();
            var result = (string)Clipboard.GetData(DataFormats.Text);
            dynamic wordApp = null;
            try
            {
                var sw = new StreamWriter("export.doc");
                sw.WriteLine(result);
                sw.Close();
                //var proc = Process.Start("export.doc");
                Type wordType = Type.GetTypeFromProgID("Word.Application");
                wordApp = Activator.CreateInstance(wordType);
                wordApp.Documents.Add(System.AppDomain.CurrentDomain.BaseDirectory + "export.doc");
                dynamic wdTable = wordApp.ActiveDocument.Range.ConvertToTable(1, DGrid.Items.Count, DGrid.Columns.Count);
                FormatTable(wdTable);


                wordApp.Visible = true;
            }
            catch (Exception ex)
            {
                if (wordApp != null)
                {
                    wordApp.Quit();
                }
                // ignored
            }
        }
        private void FormatTable(dynamic table)
        {
            dynamic borders = table.Borders;
            //wdBorderLeft
            borders[-2].LineStyle = 1;//wdLineStyleSingle
            borders[-2].LineWidth = 12;//wdLineWidth150pt
            borders[-2].Color = -16777216;
            //wdBorderRight
            borders[-4].LineStyle = 1;//wdLineStyleSingle
            borders[-4].LineWidth = 12;//wdLineWidth150pt
            borders[-4].Color = -16777216;
            //wdBorderTop
            borders[-1].LineStyle = 1;//wdLineStyleSingle
            borders[-1].LineWidth = 12;//wdLineWidth150pt
            borders[-1].Color = -16777216;
            //wdBorderBottom
            borders[-3].LineStyle = 1;//wdLineStyleSingle
            borders[-3].LineWidth = 12;//wdLineWidth150pt
            borders[-3].Color = -16777216;
            //wdBorderHorizontal
            borders[-5].LineStyle = 1;//wdLineStyleSingle
            borders[-5].LineWidth = 6;//wdLineWidth075pt
            borders[-5].Color = -16777216;
            //wdBorderVertical
            borders[-6].LineStyle = 1;//wdLineStyleSingle
            borders[-6].LineWidth = 12;//wdLineWidth150pt
            borders[-6].Color = -16777216;
        }
    }
}
