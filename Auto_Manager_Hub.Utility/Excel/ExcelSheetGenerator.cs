using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Auto_Manager_Hub.Utility.Excel
{
    public static class ExcelSheetGenerator
    {
        public static void GenerateFor<T>(IEnumerable<T> source)
        {
            var type = typeof(T);
            var typeProperties = type.GetProperties();
            string typeName = type.Name;

            string fileName = $"{typeName}{DateTime.Now.ToString("yyyy-MM-dd-hh-mm")}.xlsx";
            string DirPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string filePath = Path.Combine(DirPath, fileName);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excel=new ExcelPackage())
            {
                var sheet = excel.Workbook.Worksheets.Add(typeName);

                //Sheet Style :
                sheet.DefaultRowHeight = 20;
                sheet.Rows.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //Sheet Header : 
                short row = 1, col = 1;
                foreach (var prop in typeProperties) 
                {
                    sheet.Cells[row, col++].Value = prop.Name;
                }

                //Sheet Body :
                row++; col = 1;
                foreach (T obj in source)
                {
                    foreach (var property in typeProperties)
                    {
                        sheet.Cells[row, col++].Value = property.GetValue(obj);
                    }
                    row++;
                    col = 1;
                }

                sheet.Columns.AutoFit();
                FileStream stream = File.Create(filePath);
                stream.Close();

                File.WriteAllBytes(filePath, excel.GetAsByteArray());
            }
        }
    }
}
