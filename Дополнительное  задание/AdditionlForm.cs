using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Дополнительное__задание
{
    public partial class AdditionlForm : Form
    {
        public AdditionlForm()
        {
            InitializeComponent();
        }
        public DataGridView Data
        {
            get { return DataGridView; }
            set { DataGridView = value; }
        }

        public Label Group
        {
            get { return GroupLabel; }
            set { GroupLabel = value; }
        }
    }
}
