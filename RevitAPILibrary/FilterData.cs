using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPILibrary
{
    public class FilterData
    {
        public static List<ParameterFilterElement> GetFilters(Document doc)
        {
            var filters = new FilteredElementCollector(doc)
                            .OfClass(typeof(ParameterFilterElement))
                            .Cast<ParameterFilterElement>()
                            .ToList();
            return filters;
        }
    }
}
