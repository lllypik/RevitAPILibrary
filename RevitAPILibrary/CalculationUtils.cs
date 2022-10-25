using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPILibrary
{
    public class CalculationUtils
    {
        static public double CalculationVolumeWalls(List<Element> WallElementsList)
        {
            double volumeWallsValue = 0;

            foreach (var selectedElement in WallElementsList)
            {
                if (selectedElement is Wall)
                {
                    Parameter volumeParametr = selectedElement.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
                    volumeWallsValue += UnitUtils.ConvertFromInternalUnits(volumeParametr.AsDouble(), UnitTypeId.CubicMeters);
                }
            }

            return volumeWallsValue;
        }

    }
}
