namespace CRUD_MYSQL
{
    public partial class Form1 : Form
    {
        newStuden form;

        public Form1()
        {

            InitializeComponent();
            form = new newStuden(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form.Hide();
                form.id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.reg = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.section = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.@class = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.UpddateInfo();
                form.ShowDialog();
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Are you want to delete sruden", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    DatabaseStuden.DeleteStuden(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Disploy();
                }

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Hide();
            form.ShowDialog();

        }
        public void Disploy()
        {
            DatabaseStuden.DisplayAndSearch("SELECT id , name , reg, class,section FROM student_tabe", dataGridView1);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Disploy();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
