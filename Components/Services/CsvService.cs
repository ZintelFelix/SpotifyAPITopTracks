using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

public class CsvService
{
    public IEnumerable<PlaylistData> LoadCsvData(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<PlaylistData>().ToList();
    }
}
