using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBS
{
    
    public partial class FormMain : Form
    {
        private DataProvider dataProvider = new DataProvider();
        public FormMain()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            initSach();
        }

        private void initSach()
        {
            loadDgSach();
        }

        private void loadDgSach()
        {
            DataTable dt = new DataTable();

            StringBuilder query = new StringBuilder("SELECT * FROM tbl_sach");
            dt = dataProvider.execQuery(query.ToString());

            dgSach.DataSource = dt;
        }
       
    }
}
