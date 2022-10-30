using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPILibrary
{
    public class ScheduleData
    {
        public static List<ViewSchedule> GetAllTheSchedules(Document doc)
        {
            return new FilteredElementCollector(doc)
                .OfClass(typeof(ViewSchedule))
                .Cast<ViewSchedule>()
                .ToList();
        }
    }
}
