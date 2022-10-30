
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPILibrary
{
    public class ViewportData
    {
        public static List<Viewport> PickAllViewportType(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<Viewport> viewports = new FilteredElementCollector(doc)
                .OfClass(typeof (Viewport))
                //.OfCategory(BuiltInCategory.OST_Viewports)
                .Cast<Viewport>()
                .ToList();

            return viewports;
        }

        public static List<ViewPlan> PickAllViewplanType(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<ViewPlan> viewPlan = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewPlan))
                //.OfCategory(BuiltInCategory.OST_Viewports)
                .Cast<ViewPlan>()
                .ToList();

            return viewPlan;
        }

        public static List<View> PickAllView(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<View> views = new FilteredElementCollector(doc)
                .OfClass(typeof(View))
                //.OfCategory(BuiltInCategory.OST_Viewports)
                .Cast<View>()
                .ToList();

            return views;
        }

    }


}
