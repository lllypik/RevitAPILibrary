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

        public static List<DuctType>GetDuctType(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document document = uIDocument.Document;

            List<DuctType> ductTypeList = new FilteredElementCollector(document)
                .OfClass(typeof(DuctType))
                .Cast<DuctType>()
                .ToList();

            return ductTypeList;
        }
    }
}
