using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NEA_prototype
{
    public partial class PearsonsChartForm : Form
    {
        protected double[,] UserDataSet;
        public PearsonsChartForm(double[,] UserDataSet)
        {
            InitializeComponent();
            this.UserDataSet = UserDataSet;
        }
        private void PearsonsChartForm_Load(object sender, EventArgs e, Pearsons pearsons)
        {
            DataSet.Series.Add("RandomGeneratedPoints");
            DataSet.Series["RandomGeneratedPoints"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            for (int i = 0; i < UserDataSet.GetLength(0); i++)
                DataSet.Series["RandomGeneratedPoints"].Points.AddXY(UserDataSet[i, 0], UserDataSet[i, 1]);
        }
    }
}