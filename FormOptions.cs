using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heic2Whatever
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            var fff = GetEnumValues<MagickFormat>();
        }

        private List<string> GetEnumValues<T>()
        {
            Type t_type = typeof(T);

            FieldInfo[] field_infos = t_type.GetFields();

            var results = new List<string>();
            foreach (FieldInfo field_info in field_infos)
            {
                if (field_info.IsLiteral)
                {
                    results.Add(field_info.GetValue(null).ToString());
                }
            }

            return results;
        }
    }
}
