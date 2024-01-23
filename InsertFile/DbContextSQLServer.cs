using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace InsertFile
{
    class DbContextSQLServer : DbContext
    {
        // Định nghĩa các DbSet cho các đối tượng trong mô hình dữ liệu
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Score> Scores { get; set; }

        // Phương thức cấu hình kết nối đến cơ sở dữ liệu
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Thay thế "Your_Connection_String" bằng chuỗi kết nối SQL Server thực tế của bạn
                optionsBuilder.UseSqlServer("Server=DESKTOP-GCOTT5N\\CAOKIENQUOC;Database=DSSV;User Id=sa;Password=12345;");
            }
        }
    }
}
