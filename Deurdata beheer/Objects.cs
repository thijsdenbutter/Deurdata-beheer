using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;


namespace Deurdata_beheer
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LabelAttribute : Attribute
    {
        public string Text { get; }

        public LabelAttribute(string text)
        {
            Text = text;
        }
    }
    public class EnumItem<T>
    {
        public T Value { get; set; }
        public string Label { get; set; }

        public override string ToString() => Label;
    }

    public class ProjectInfo
    {
        [Label("Order nummer")]
        public int OrderNumber { get; set; }
        [Label("Project naam")]
        public string ProjectName { get; set; }
        [Label("Project referentie")]
        public string ProjectReference { get; set; }
        [Label("Deuren")]
        public List<Sash> Sashes { get; set; } = new List<Sash>();
    }

    public enum OpeningType
    {
        [Description("Links binnen")]
        LeftOpenIn,
        [Description("Rechts binnen")]
        RightOpenIn,
        [Description("Links buiten")]
        LeftOpenOut,
        [Description("Rechts buiten")]
        RightOpenOut
    }

    public class Geometry
    {
        [Label("Bovendorpel")]
        public List<Point> TopTransom { get; set; } = new List<Point>();

        [Label("Onderdorpel")]
        public List<Point> BottomTransom { get; set; } = new List<Point>();

        [Label("Linkerstijl")]
        public List<Point> LeftPost { get; set; } = new List<Point>();

        [Label("Rechterstijl")]
        public List<Point> RightPost { get; set; } = new List<Point>();

    }
    public class Point
    {
        [Label("Lengte")]
        public double Length { get; set; }
        public double Offset { get; set; }
    }

    public class Sash
    {
        // Algemeen
        [Label("Breedte")]
        public double Width { get; set; }
        [Label("Hoogte")]
        public double Height { get; set; }
        [Label("Dikte")]
        public double Thickness { get; set; }
        [Label("Draairichting")]
        public OpeningType Opening { get; set; }
        [Label("Geometrie")]
        public Geometry Geometry { get; set; } = new Geometry();

        //public bool DoubleOpening { get; set; }

        //Hang- en sluitwerk
        [Label("Slot configuratie")]
        public HardwareItem LockConfiguration { get; set; } = new HardwareItem();
        [Label("Scharnier type")]
        public HardwareItem HingeType { get; set; }
        [Label("Kruk hoogte")]
        public double HandleHeight { get; set; } = 1050;
        [Label("Scharnier posities")]
        public List<double> HingePositions { get; set; }
    }
    public class HardwareItem
    {
        [Label("Naam")]
        public string Name { get; set; } = "";
        [Label("Artikel nummer")]
        public string Code { get; set; } = "";
    }


}
