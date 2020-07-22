using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_QLKS
{
    public partial class FrmLogin : Form
    {
        
        public bool IsLogin { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
            
            IsLogin = false;
            
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            

        }
        private void bt_DN_Click(object sender, EventArgs e)
        {
            string tk = tb_TenTK.Text;
            string mk = tb_MK.Text;
            string strError = string.Empty;
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-13DJ6LQ\SQLEXPRESS;Initial Catalog=QlyKhachSan;Integrated Security=true");
            try
            {
                conn.Open();
                if (tk == string.Empty)
                {
                    strError = "Bạn vui lòng nhập tên đăng nhập ";
                }
                if (mk == string.Empty)
                {
                    strError += "Bạn chưa nhập mật khẩu";
                }
                if (strError != string.Empty)
                {
                    MessageBox.Show("Lỗi :" + strError);
                    return;
                }
                string sql = "select * from NguoiDung where TaiKhoan = '" + tk + "' and MatKhau = '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    IsLogin = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại : Sai tài khoản hoặc mật khẩu", "Thông báo");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void bt_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            };
            
        }
    }
}
