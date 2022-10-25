using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPILibrary
{
    public class DuctData


    {

        public static List<Duct> GetDuctType(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document document = uIDocument.Document;

            List<Duct> ductTypeList = new FilteredElementCollector(document)
                .OfClass(typeof(Duct))
                .Cast<Duct>()
                .ToList();

            return ductTypeList;
        }
    }
}
