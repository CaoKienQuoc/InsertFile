using InsertFile.Object;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InsertFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbContextSQLServer dbContext;
        public MainWindow()
        {
            InitializeComponent();
            dbContext = new DbContextSQLServer();

            // Binding dữ liệu từ ObservableCsvDataList vào ListView
            dataListView.ItemsSource = CSVDataReader.ObservableCsvDataList;

            // Binding dữ liệu từ ObservableCsvDataList vào ListView
            dataListView.ItemsSource = CSVDataReader.ObservableCsvDataList;

            cboYear.ItemsSource = new List<int> { 2017, 2018, 2019, 2020, 2021 };
            cboYear.SelectedIndex = 0;

            CSVDataReader.SelectedYear = (int)cboYear.SelectedItem;
        }

        

        private void btnBrown_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

            if(openFileDialog.ShowDialog()==true)
            {
                //lay duong dan
                string filePath = openFileDialog.FileName;

                //cap nhat gia tri nam tu combobox
                CSVDataReader.SelectedYear = (int)cboYear.SelectedItem;

                //xoa du lieu cu 
                Application.Current.Dispatcher.Invoke(() => CSVDataReader.ObservableCsvDataList.Clear());

                CSVDataReader.LoadAndDispayData(filePath, dataListView);
            }
        }

        private void cboYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Cập nhật giá trị năm khi người dùng thay đổi ComboBox
            CSVDataReader.SelectedYear = (int)cboYear.SelectedItem;
        }
    }
}