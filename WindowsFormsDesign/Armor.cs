using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDesign
{
    class Armor
    {
        public Image Portrait;
        public string Name { get; set; }
        public string HeadMaterials { get; set; }
        public string TorsoMaterials { get; set; }
        public string ArmsMaterials { get; set; }
        public string WaistMaterial { get; set; }
        public string FeetMaterial { get; set; }

        public Armor(string pic, string name, string hm,string tm,string am,string wm,string fm)
        {
            Portrait = Image.FromFile(pic);
            Name = name;
            HeadMaterials = hm;
            TorsoMaterials = tm;
            ArmsMaterials = am;
            WaistMaterial = wm;
            FeetMaterial = fm;
        }
    }
}
