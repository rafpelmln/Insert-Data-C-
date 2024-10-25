// 3.
using System.Data;
using System.Data.SqlClient;

namespace insertfarrel
{
    public partial class Form1 : Form
    {
        // 4.
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        // 5.
        koneksi Konn = new koneksi();

        public Form1()
        {
            InitializeComponent();
        }

        void Bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "";
        }

        // BUAT MASUKIN DATA DARI DATABASE KE GRIDVIEW
        void TampilBarang()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM TBL_BARANG", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "TBL_BARANG");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "TBL_BARANG";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {

                MessageBox.Show(G.ToString());

            }
            finally
            {
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TampilBarang();
            Bersihkan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap !");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try 
                { 
                    cmd = new SqlCommand("INSERT INTO TBL_BARANG VALUES('" + textBox1.Text +"','"+ textBox2.Text + "','" + textBox3.Text +"','"+ textBox4.Text + "','" + textBox5.Text +"','"+ textBox6.Text +"')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Data Berhasil");
                    TampilBarang();
                    Bersihkan();
                }
                catch (Exception X)
                {
                    MessageBox.Show(X.ToString());

                }
            }
        }
    }
}
