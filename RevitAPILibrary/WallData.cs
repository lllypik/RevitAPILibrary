using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPILibrary
{
    public class WallData
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Volume { get; set; }

        public double Length { get; set; }



        public static List<WallType> GetWallType(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document document = uIDocument.Document;

            List<WallType> wallTypeList = new FilteredElementCollector(document)
                .OfClass(typeof(WallType))
                .Cast<WallType>()
                .ToList();

            return wallTypeList;
        }


    }
}
