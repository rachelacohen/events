using CsvHelper;
using System.Globalization;

namespace Api_Calender
{
    public class DataContext : IDataContext
    {
        public List<Event> EventList { get; set; }
        List<Event> IDataContext.EventList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DataContext()
        {
            using (var reader = new StreamReader("data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                EventList = csv.GetRecords<Event>().ToList();
            }
        }


    }
}
