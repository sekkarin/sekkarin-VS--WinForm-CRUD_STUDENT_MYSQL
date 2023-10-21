using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_MYSQL
{
    public partial class newStuden : Form
    {
        private readonly Form1 _parent;
      public  string id, name, reg, @class, section;
        public newStuden(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();

        }
        public void UpddateInfo()
        {
            label1.Text = "Update Student";
            button1.Text = "update";
            textBox1.Text = name;
            textBox2.Text = reg;
            textBox3.Text = @class;
            textBox4.Text = section;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length < 3)
            {
                MessageBox.Show("Studen name is short or Emtry");
                return;
            }
            if (button1.Text == "save")
            {
                student std = new student(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim());
                DatabaseStuden.AddStudent(std);
            }
            if (button1.Text == "update")
            {
                student std = new student(textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim());
                DatabaseStuden.UpdateStudent(std, id);
            }

            _parent.Disploy();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
