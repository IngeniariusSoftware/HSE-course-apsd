using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeirachicalTimetable
{
    public partial class MainForm : Form
    {
        public int WorkerCount { get; set; }
        private List<List<string>> Jobs;
        public MainForm()
        {

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            var workerCount = Int32.Parse(textBox.Text);
            WorkerCount = workerCount;
            var charsTuples = Reader.Read();
            List<Point> points = new List<Point>();
            foreach (var name in Reader.GetUniquChars(charsTuples))
            {
                points.Add(new Point(name));
            }

            Jobs = Reader.Sheduler(points, charsTuples, workerCount);
            Clear();
            workGrid.RowCount = WorkerCount;
            workGrid.ColumnCount = Jobs.Count;
            workGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            workGrid.RowHeadersWidth += 10;
            for (int i = 0; i < workerCount; i++)
            {
                workGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            var jobsString = new List<string>();
            for (int i = 0; i < Jobs.Count(); i++)
            {
                workGrid.Columns[i].HeaderText = (i + 1).ToString();
                for (int j = 0; j < Jobs[i].Count; j++)
                {
                    workGrid[i, j].Value = Jobs[i][j];
                    if (Jobs[i][j] != null)
                        jobsString.Add(Jobs[i][j]);
                }
            }
            workLineGrid.RowCount = 2;
            workLineGrid.ColumnCount = jobsString.Count;

            int current = 0;
            for (int y = 0; y < Jobs.Count; y++)
            {
                for (int x = 0; x < Jobs[y].Count; x++)
                {
                    workLineGrid[current, 0].Value = Jobs[y][x];
                    workLineGrid[current, 1].Value = jobsString.Count - current;
                    current++;
                }
                
            }
        }

        private void Clear()
        {
            for (int y = 0; y < workGrid.RowCount; y++)
            {
                for (int x = 0; x < workGrid.ColumnCount; x++)
                {
                    workGrid[x, y].Value = null;
                }
            }
        }

        private void workGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
