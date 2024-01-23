using InsertFile.Object;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InsertFile
{
    class CSVDataReader
    {
        private static ObservableCollection<CsvData> observableCsvDataList;

        public static int SelectedYear { get; set; }

        public static ObservableCollection<CsvData> ObservableCsvDataList
        {
            get
            {
                if (observableCsvDataList == null)
                {
                    observableCsvDataList = new ObservableCollection<CsvData>();
                }
                return observableCsvDataList;
            }
        }
        public static List<CsvData> LoadAndDispayData(string filePath, ListView listView)
        {
            List<CsvData> csvDataList = new List<CsvData>();
            int batchSize = 500000;


            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Bỏ qua dòng header nếu có
                if (!parser.EndOfData) parser.ReadLine();

                while (!parser.EndOfData)
                {
                    //doc 1 file tu batch
                    List<string[]> batch = ReadBatch(parser, batchSize);

                    // Xử lý batch
                    List<CsvData> processedBatch = ProcessBatch(batch);

                    // Lọc và thêm vào danh sách chính
                    csvDataList.AddRange(processedBatch.Where(data => data.Year == SelectedYear));

                    // In thông báo cho biết mỗi khi một batch được xử lý
                    Console.WriteLine($"Processed a batch of {batch.Count} rows.");
                }

                // Hiển thị dữ liệu trong ListView
                listView.ItemsSource = csvDataList;

                return csvDataList;
            }
        }

        private static List<string[]> ReadBatch(TextFieldParser parser, int batchSize)
        {
            List<string[]> batch = new List<string[]>();
            for (int i = 0; i < batchSize && !parser.EndOfData; i++)
            {
                batch.Add(parser.ReadFields());
            }
            return batch;
        }

        private static List<CsvData> ProcessBatch(List<string[]> batch)
        {
            List<CsvData> result = new List<CsvData>();

            foreach (var fields in batch)
            {
                CsvData csvData = new CsvData();

                csvData.SBD  = TryParseInt(fields[0]);
                csvData.Toan = TryParseDouble(fields[1]);
                csvData.Van = TryParseDouble(fields[2]);
                csvData.Ly = TryParseDouble(fields[3]);
                csvData.Sinh = TryParseDouble(fields[4]);
                csvData.NgoaiNgu = TryParseDouble(fields[5]);
                csvData.Year = TryParseInt(fields[6]);
                csvData.Hoa = TryParseDouble(fields[7]);
                csvData.Lichsu = TryParseDouble(fields[8]);
                csvData.Dialy = TryParseDouble(fields[9]);
                csvData.GDCD = TryParseDouble(fields[10]);
                csvData.MaTinh = TryParseInt(fields[11]);

                result.Add(csvData);

                // In thông báo cho biết mỗi khi một dòng dữ liệu được xử lý
                Console.WriteLine($"Processed data: {csvData.SBD}, {csvData.Toan}, ...");
            }

            return result;
        }

        private static int TryParseInt(string value)
        {
            int resultl;
            return int.TryParse(value, out resultl) ? resultl : 0;
        }

        private static double TryParseDouble(string value)
        {
            double result;
            return double.TryParse(value, out result) ? result : 0.0;
        }
    }
}