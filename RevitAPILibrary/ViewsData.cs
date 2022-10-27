
using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace RevitAPILibrary
{
    public class ViewsData
    {
        public static List<ViewPlan> GetFloorPlanViews(Document doc)
        {
            List<ViewPlan> views = new FilteredElementCollector(doc)
                   .OfClass(typeof(ViewPlan))
                   .Cast<ViewPlan>()
                   .Where(p => p.ViewType == ViewType.FloorPlan)
                   .ToList();
            return views;
        }
    }
}
