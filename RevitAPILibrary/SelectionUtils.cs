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
    public class SelectionUtils
    {

        static public Element PickObject(ExternalCommandData commandData, string message = "Выберите один элемент")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document document = uIDocument.Document;

            var selectedObject = uIDocument.Selection.PickObject(ObjectType.Element, message);
            var oElement = document.GetElement(selectedObject);
            return oElement;
        }


        public static List<Element> PickObjects(ExternalCommandData commandData, string message = "Выберите несколько элементов")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document document = uIDocument.Document;

            var selectedObjects = uIDocument.Selection.PickObjects(ObjectType.Element, message);
            List<Element> elementList = selectedObjects.Select(selectedObject => document.GetElement(selectedObject)).ToList();
            return elementList;
        }


        static public List<Pipe> PickAllPipes(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document document = uIDocument.Document;

            List<Pipe> pipeList = new List<Pipe>();
            pipeList = new FilteredElementCollector(document)
                .OfCategory(BuiltInCategory.OST_PipeCurves)
                .WhereElementIsNotElementType()
                .Cast<Pipe>()
                .ToList();
            return pipeList;
        }


        static public List<Wall> PickAllWalls(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document document = uIDocument.Document;

            List<Wall> wallList = new List<Wall>();
            wallList = new FilteredElementCollector(document)
                .OfClass(typeof(Wall))
                .Cast<Wall>()
                .ToList();
            return wallList;
        }


        static public List<Element> PickAllElementsWall(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document document = uIDocument.Document;

            List<Element> elementsWallList = new List<Element>();
            elementsWallList = new FilteredElementCollector(document)
                .OfClass(typeof(Wall))
                .Cast<Element>()
                .ToList();
            return elementsWallList;
        }


        static public List<FamilyInstance> PickAllDoors(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document document = uIDocument.Document;

            List<FamilyInstance> doorsList = new List<FamilyInstance>();
            doorsList = new FilteredElementCollector(document)
                .OfCategory(BuiltInCategory.OST_Doors)
                .WhereElementIsNotElementType()
                .Cast<FamilyInstance>()
                .ToList();
            return doorsList;
        }


        static public List<XYZ> GetPoints(ExternalCommandData commandData, string message, ObjectSnapTypes objectSnapTypes)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;

            List<XYZ> points = new List<XYZ>();

            while (true)
            {
                XYZ pickedPoint = null;
                try
                {
                    pickedPoint = uIDocument.Selection.PickPoint(objectSnapTypes, message);
                }
                catch (Autodesk.Revit.Exceptions.OperationCanceledException ex)
                {
                    break;
                }
                points.Add(pickedPoint);
            }
            return points;
        }


        static public XYZ GetPoint(ExternalCommandData commandData, string message, ObjectSnapTypes objectSnapTypes)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;

            XYZ pickedPoint = uIDocument.Selection.PickPoint(objectSnapTypes, message);
               
            return pickedPoint;
        }


        public static T GetObject<T>(ExternalCommandData commandData, string promptMessage)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            Reference selectedObj = null;
            T elem;
            try
            {
                selectedObj = uidoc.Selection.PickObject(ObjectType.Element, promptMessage);

            }
            catch (Exception)
            {
                return default(T);
            }
            elem = (T)(object)doc.GetElement(selectedObj.ElementId);
            return elem;
        }



    }
}
