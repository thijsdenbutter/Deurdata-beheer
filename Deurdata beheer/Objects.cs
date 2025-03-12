using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deurdata_beheer
{
    // Attribute to define export names
    [AttributeUsage(AttributeTargets.Property)]
    public class ExportNameAttribute : Attribute
    {
        public string Name { get; }
        public ExportNameAttribute(string name) => Name = name;
    }

    public enum OpeningDirectionType
    {
        [Description("NormalLeftOpen")] NS,
        [Description("NormalRightOpen")] ND,
    }

    public class StructureParameters
    {
        [ExportName("Sezione_Mont_SX")]
        public double LeftPostSection { get; set; }

        [ExportName("Sezione_Tra_SUP")]
        public double TopTransomSection { get; set; }

        [ExportName("Sezione_Mont_DX")]
        public double RightPostSection { get; set; }

        [ExportName("Sezione_Tra_INF")]
        public double BottomTransomSection { get; set; }

        [ExportName("Spessore")]
        public double Thickness { get; set; }
    }

    public class Frame
    {
        public StructureParameters StructureParameters { get; set; }
    }
    public class Sash
    {
        public StructureParameters StructureParameters { get; set; }
    }

    public class Row
    {
        [ExportName("RIFERIMENTO")]
        public string Reference { get; set; }

        [ExportName("DESCRIZIONE_RIGA")]
        public string RowDescription { get; set; }

        [ExportName("PROGETTO_DEFAULT")]
        public string DefaultProject { get; set; } = "EMPTY";

        [ExportName("Posizione")]
        public int Position { get; set; }

        [ExportName("Quantità")]
        public int Quantity { get; set; }

        [ExportName("Configurazione_Telaio")]
        public string FrameConfiguration { get; set; }

        [ExportName("Configurazione_Anta")]
        public string SashConfiguration { get; set; }

        [ExportName("Configurazione_Ferramenta")]
        public string HardwareConfiguration { get; set; }

        [ExportName("Larghezza_Serramento")]
        public decimal Width { get; set; }

        [ExportName("Altezza_Serramento")]
        public decimal Height { get; set; }

        [ExportName("Forma_Esterna")]
        public string OuterShape { get; set; } = "RETTANGOLO";

        [ExportName("Soglia")]
        public string Threshold { get; set; } = "L";

        [ExportName("Spessore_Telaio")]
        public decimal FrameThickness { get; set; } = 0;

        [ExportName("Numero_Ante")]
        public int NumberOfSashes { get; set; } = 1;

        [ExportName("Anta_apre")]
        public int SashOpening { get; set; } = 1;

        [ExportName("Sormonto_DX")]
        public decimal RightOverlap { get; set; } = 0;

        [ExportName("Sormonto_SUP")]
        public decimal TopOverlap { get; set; } = 0;

        [ExportName("Sormonto_SX")]
        public decimal LeftOverlap { get; set; } = 0;

        [ExportName("Sormonto_INF")]
        public decimal BottomOverlap { get; set; } = 0;

        [ExportName("Apertura")]
        public OpeningDirectionType OpeningDirection { get; set; }

        [ExportName("Note_Riga")]
        public string RowNotes { get; set; }

        public Frame Frame { get; set; }
        public Sash Sash { get; set; }
    }

    public class OrderHeader
    {
        [ExportName("Numero_Commessa")]
        public int OrderNumber { get; set; }

        [ExportName("Descrizione_Commessa")]
        public string OrderDescription { get; set; }

        [ExportName("Riferimento")]
        public string Customer { get; set; }

        [ExportName("Numero_Righe")]
        public int NumberOfRows { get; set; }

        public List<Row> Rows { get; set; } = new List<Row>();
    }

}
