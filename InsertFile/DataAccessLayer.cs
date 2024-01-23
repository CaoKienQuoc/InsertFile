/*using InsertFile.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InsertFile
{
    class DataAccessLayer
    {
        private readonly DbContextSQLServer _dbContext;

        public DataAccessLayer()
        {
            _dbContext = new DbContextSQLServer();
        }

        public void InsertDataToDatabase(List<CsvData> csvDataList)
        {
            foreach (var csvData in csvDataList)
            {
                if (csvData.Year == CSVDataReader.SelectedYear)
                {
                    Student student = new Student
                    {
                        StudentCode = csvData.SBD,
                        SchoolYearID = csvData.Year,
                        Status = 1
                        // Các trường khác tương ứng
                    };

                    Subject subject = new Subject
                    {
                        Code = csvData.SubjectCode,
                        Name = csvData.SubjectName
                        // Các trường khác tương ứng
                    };

                    Score score = new Score
                    {
                        StudentID = student.StudentCode,
                        SubjectID = subject.ID,
                        ScoreDiem = csvData.ScoreDiem
                        // Các trường khác tương ứng
                    };

                    SchoolYear schoolYear = new SchoolYear
                    {
                        Name = csvData.SchoolYearName,
                        ExamYear = csvData.ExamYear,
                        Status = csvData.SchoolYearStatus
                        // Các trường khác tương ứng
                    };

                    _dbContext.Students.Add(student);
                    _dbContext.Subjects.Add(subject);
                    _dbContext.Scores.Add(score);
                    _dbContext.SchoolYears.Add(schoolYear);

                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
*/