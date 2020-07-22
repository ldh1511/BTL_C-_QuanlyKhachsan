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
    public partial class Form1 : Form
    {
        string conStr = "Data Source = DESKTOP-13DJ6LQ\\SQLEXPRESS; Initial Catalog=QlyKhachSan; Integrated Security=true";

        public Form1()
        {
            InitializeComponent();
            
        }
        SqlConnection conn = null;
        DataTable dtKH, dtNV, dtP, dtDP, dtHD, dtLdp;
        SqlDataAdapter da, daNV, daP, daDP, daHD, daLdp;
        int index;
        int slk, giaphong, slp, sln;
        string gt;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
            string sql = "SELECT * FROM KHACH";
            da = new SqlDataAdapter(sql, conn);
            dtKH = new DataTable();
            da.Fill(dtKH);
            dataGridView1.DataSource = dtKH;


            sql = "SELECT * FROM NHANVIEN";
            daNV = new SqlDataAdapter(sql, conn);
            dtNV = new DataTable();
            daNV.Fill(dtNV);
            dataNhanVien.DataSource = dtNV;

            sql = "SELECT * FROM PHONG";
            daP = new SqlDataAdapter(sql, conn);
            dtP = new DataTable();
            daP.Fill(dtP);
            listView1.View = View.LargeIcon;
            int i = 0;
            foreach (DataRow row in dtP.Rows)
            {
                listView1.Items.Add(dtP.Rows[i]["Maphong"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Trangthai"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Sl_nguoi"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Loai_phong"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Gia_phong"].ToString());
                listView1.Items[i].ImageIndex = 0;
                i++;
            }
            

            sql = "SELECT * FROM CTDATPHONG";
            daDP = new SqlDataAdapter(sql, conn);
            dtDP = new DataTable();
            daDP.Fill(dtDP);
            dataDPhong.DataSource = dtDP;
            cb_DP_Khach.DataSource = dtDP;
            cb_DP_Khach.DisplayMember = "Madatphong";

            sql = "SELECT DISTINCT Loai_phong FROM PHONG";
            daLdp = new SqlDataAdapter(sql, conn);
            dtLdp = new DataTable();
            daLdp.Fill(dtLdp);
            

            sql = "SELECT * FROM KHACH";
            daHD = new SqlDataAdapter(sql, conn);
            dtHD = new DataTable();
            daHD.Fill(dtHD);
            dataGridView2.DataSource = dtHD;
        }
        // Khách
        private void bt_Them_Click(object sender, EventArgs e)
        {
            if (Kiemtra()) 
            {
                try
                {
                    string sql = "INSERT INTO KHACH VALUES(@Makhach,@Ten_k,@Sdt_k,@Dc_khach,@No_CMND,@Maphong,@Ngay_np,@Ngay_tp, @Madatphong)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@Makhach", SqlDbType.VarChar).Value = tb_Makhach.Text;
                    cmd.Parameters.Add("@Ten_k", SqlDbType.NVarChar).Value = tb_Ten_k.Text;
                    cmd.Parameters.Add("@Sdt_k", SqlDbType.Char).Value = tb_Sdt_k.Text;
                    cmd.Parameters.Add("@Dc_khach", SqlDbType.NVarChar).Value = cb_Dc.Text;
                    cmd.Parameters.Add("@No_CMND", SqlDbType.Char).Value = tb_No_CMND.Text;
                    cmd.Parameters.Add("@Maphong", SqlDbType.VarChar).Value = tb_Map_Khach.Text;
                    cmd.Parameters.Add("@Ngay_np", SqlDbType.Date).Value = dtp_1.Value;
                    cmd.Parameters.Add("@Ngay_tp", SqlDbType.Date).Value = dtp_2.Value;
                    cmd.Parameters.Add("@Madatphong", SqlDbType.VarChar).Value = cb_DP_Khach.Text;
                    cmd.ExecuteNonQuery();
                    dtKH.Clear();
                    da.Fill(dtKH);
                    MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");
                    tb_Makhach.Clear();
                    tb_Madp.Clear();
                    tb_Ten_k.Clear();
                    tb_Sdt_k.Clear();
                    tb_No_CMND.Clear();
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại thông tin\n" + loi.Message, "Thông báo");
                }

            }
        }

        private void bt_Sua_Click(object sender, EventArgs e)
        {
            if (Kiemtra())
            {
                try
                {
                    string sql = "UPDATE KHACH " +
                    "SET Makhach=@Makhach, Ten_k=@Ten_k,Sdt_k=@Sdt_k,Dc_khach=@Dc_khach,No_CMND=@No_CMND," +
                    "Maphong=@Maphong,Ngay_np=@Ngay_np,Ngay_tp=@Ngay_tp,Madatphong=@Madatphong WHERE Makhach=@Makhach";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@Makhach", SqlDbType.VarChar).Value = tb_Makhach.Text;
                    cmd.Parameters.Add("@Ten_k", SqlDbType.NVarChar).Value = tb_Ten_k.Text;
                    cmd.Parameters.Add("@Sdt_k", SqlDbType.Char).Value = tb_Sdt_k.Text;
                    cmd.Parameters.Add("@Dc_khach", SqlDbType.NVarChar).Value = cb_Dc.Text;
                    cmd.Parameters.Add("@No_CMND", SqlDbType.Char).Value = tb_No_CMND.Text;
                    cmd.Parameters.Add("@Maphong", SqlDbType.VarChar).Value = tb_Map_Khach.Text;
                    cmd.Parameters.Add("@Ngay_np", SqlDbType.Date).Value = dtp_1.Value;
                    cmd.Parameters.Add("@Ngay_tp", SqlDbType.Date).Value = dtp_2.Value;
                    cmd.Parameters.Add("@Madatphong", SqlDbType.VarChar).Value = cb_DP_Khach.Text;
                    cmd.ExecuteNonQuery();
                    dtKH.Rows.Clear();
                    da.Fill(dtKH);
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                    tb_Makhach.Clear();
                    tb_Madp.Clear();
                    tb_Ten_k.Clear();
                    tb_Sdt_k.Clear();
                    tb_No_CMND.Clear();
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại thông tin\n" + loi.Message, "Thông báo");
                }
            }
        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "DELETE FROM KHACH WHERE Makhach=@Makhach";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Makhach", SqlDbType.VarChar).Value = tb_Makhach.Text;
                cmd.ExecuteNonQuery();
                dtKH.Rows.Clear();
                da.Fill(dtKH);
                tb_Makhach.Clear();
                tb_Madp.Clear();
                tb_Ten_k.Clear();
                tb_Sdt_k.Clear();
                tb_No_CMND.Clear();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                tb_Makhach.Text = dataGridView1.Rows[index].Cells["Makhach"].Value.ToString();
                tb_Ten_k.Text = dataGridView1.Rows[index].Cells["Ten_k"].Value.ToString();
                tb_Sdt_k.Text = dataGridView1.Rows[index].Cells["Sdt_k"].Value.ToString();
                cb_Dc.Text = dataGridView1.Rows[index].Cells["Dc_khach"].Value.ToString();
                tb_No_CMND.Text = dataGridView1.Rows[index].Cells["No_CMND"].Value.ToString();
                tb_Map_Khach.Text = dataGridView1.Rows[index].Cells["Maphong"].Value.ToString();
                dtp_1.Value = Convert.ToDateTime(dataGridView1.Rows[index].Cells["Ngay_np"].Value);
                dtp_2.Value = Convert.ToDateTime(dataGridView1.Rows[index].Cells["Ngay_tp"].Value);
                cb_DP_Khach.Text = dataGridView1.Rows[index].Cells["Madatphong"].Value.ToString();
            }
        }

        private void bt_FindMK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_FindMK.Text))
            {
                string sql = "SELECT * FROM KHACH WHERE Makhach='" + tb_FindMK.Text + "'";
                da = new SqlDataAdapter(sql, conn);
                dtKH = new DataTable();
                da.Fill(dtKH);
                dataGridView1.DataSource = dtKH;
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập Mã khách", "Thông báo");
            }
        }

        private void bt_FindDC_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cb_FindDC.Text))
            {
                string sql = "SELECT * FROM KHACH WHERE Dc_khach=N'" + cb_FindDC.Text + "'";
                da = new SqlDataAdapter(sql, conn);
                dtKH = new DataTable();
                da.Fill(dtKH);
                dataGridView1.DataSource = dtKH;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn Địa chỉ", "Thông báo");
            }
        }

        
        // Nhân viên
        private void button5_Click(object sender, EventArgs e)
        {
            if (Check2())
            {
                try
                {
                    string sql = "UPDATE NHANVIEN SET Manv=@Manv,Ten_nv=@Ten_nv,Dc_nv=@Dc_nv,Gt_nv=@Gt_nv,Sdt_nv=@Sdt_nv where Manv=@Manv";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@Manv", SqlDbType.VarChar).Value = tb_MaNV.Text;
                    cmd.Parameters.Add("@Ten_nv", SqlDbType.NVarChar).Value = tb_Ten_nv.Text;
                    cmd.Parameters.Add("@Dc_nv", SqlDbType.NVarChar).Value = cb_Dc_nv.Text;
                    if (rd_Nam.Checked == true)
                    {
                        gt = "Nam";
                    }
                    else
                    {
                        gt = "Nữ";
                    }
                    cmd.Parameters.Add("@Gt_nv", SqlDbType.NVarChar).Value = gt;
                    cmd.Parameters.Add("@Sdt_nv", SqlDbType.VarChar).Value = tb_SdtNV.Text;
                    cmd.ExecuteNonQuery();
                    dtNV.Rows.Clear();
                    daNV.Fill(dtNV);
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                    tb_MaNV.Clear();
                    tb_Ten_nv.Clear();
                    tb_SdtNV.Clear();
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại thông tin\n" + loi.Message, "Thông báo");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "DELETE FROM NHANVIEN WHERE Manv=@Manv";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Manv", SqlDbType.VarChar).Value = tb_MaNV.Text;
                cmd.ExecuteNonQuery();
                dtNV.Rows.Clear();
                daNV.Fill(dtNV);
            }
        }

        private void bt_FindMNV_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_FindMNV.Text))
            {
                string sql = "SELECT * FROM NHANVIEN WHERE Manv='" + tb_FindMNV.Text + "'";
                daNV = new SqlDataAdapter(sql, conn);
                dtNV = new DataTable();
                daNV.Fill(dtNV);
                dataNhanVien.DataSource = dtNV;
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập Mã nhân viên", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cb_FinDC.Text))
            {
                string sql = "SELECT * FROM NHANVIEN WHERE Dc_nv=N'" + cb_FinDC.Text + "'";
                daNV = new SqlDataAdapter(sql, conn);
                dtNV = new DataTable();
                daNV.Fill(dtNV);
                dataNhanVien.DataSource = dtNV;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn Địa chỉ", "Thông báo");
            }
        }

        private void dataNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                tb_MaNV.Text = dataNhanVien.Rows[index].Cells["Manv"].Value.ToString();
                tb_Ten_nv.Text = dataNhanVien.Rows[index].Cells["Ten_nv"].Value.ToString();
                cb_Dc_nv.Text = dataNhanVien.Rows[index].Cells["Dc_nv"].Value.ToString();
                gt = dataNhanVien.Rows[index].Cells["Gt_nv"].Value.ToString();
                if (gt == "Nam")
                {
                    rd_Nam.Checked = true;
                }
                else
                {
                    rd_Nu.Checked = true;
                }

                tb_SdtNV.Text = dataNhanVien.Rows[index].Cells["Sdt_nv"].Value.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "DELETE FROM NHANVIEN WHERE Manv=@Manv";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Manv", SqlDbType.VarChar).Value = tb_MaNV.Text;
                cmd.ExecuteNonQuery();
                dtNV.Rows.Clear();
                daNV.Fill(dtNV);
                tb_MaNV.Clear();
                tb_Ten_nv.Clear();
                tb_SdtNV.Clear();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Check2())
            {
                try
                {
                    string sql = "INSERT INTO NHANVIEN VALUES(@Manv,@Ten_nv,@Dc_nv,@Gt_nv,@Sdt_nv)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@Manv", SqlDbType.VarChar).Value = tb_MaNV.Text;
                    cmd.Parameters.Add("@Ten_nv", SqlDbType.NVarChar).Value = tb_Ten_nv.Text;
                    cmd.Parameters.Add("@Dc_nv", SqlDbType.NVarChar).Value = cb_Dc_nv.Text;
                    if (rd_Nam.Checked == true)
                    {
                        gt = "Nam";
                    }
                    else
                    {
                        gt = "Nữ";
                    }
                    cmd.Parameters.Add("@Gt_nv", SqlDbType.NVarChar).Value = gt;
                    cmd.Parameters.Add("@Sdt_nv", SqlDbType.VarChar).Value = tb_SdtNV.Text;
                    cmd.ExecuteNonQuery();
                    dtNV.Clear();
                    daNV.Fill(dtNV);
                    MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");
                    tb_MaNV.Clear();
                    tb_Ten_nv.Clear();
                    tb_SdtNV.Clear();
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại thông tin\n" + loi.Message, "Thông báo");
                }
            }
        }
        // Phòng
        private void UpdatePhong()
        {
            string sql_update = "update PHONG set PHONG.Trangthai=N'NULL' ";
            SqlCommand cmd = new SqlCommand(sql_update, conn);
            cmd.ExecuteNonQuery();
            listView1.Items.Clear();

        }

        private void UpdatePhong2()
        {
            string sql_update = "update PHONG set Trangthai=N'Có người' from PHONG inner join KHACH on PHONG.Maphong=KHACH.Maphong " +
                "where PHONG.Maphong=KHACH.Maphong and KHACH.Ngay_tp >= Getdate();";
            SqlCommand cmd = new SqlCommand(sql_update, conn);
            cmd.ExecuteNonQuery();
            listView1.Items.Clear();

        }

        private void bt_XoaP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sql = "delete from PHONG where Maphong=@Maphong";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@Maphong", SqlDbType.VarChar).Value = tb_Maphong.Text;
                cmd.ExecuteNonQuery();
                daP.Fill(dtP);
                MessageBox.Show("Xóa phòng thành công, hãy cập nhật lại dữ liệu", "Thông báo");
                tb_Maphong.Clear();
                tb_LoaiP.Clear();
                tb_SLN.Clear();
                tb_GiaP.Clear();
                tb_Trthai.Clear();
            }
        }

        
        private void bt_UpdateP_Click(object sender, EventArgs e)
        {
            UpdatePhong();
            UpdatePhong2();
            string sql = "SELECT * FROM PHONG";
            daP = new SqlDataAdapter(sql, conn);
            dtP = new DataTable();
            listView1.Items.Clear();
            daP.Fill(dtP);
            listView1.View = View.LargeIcon;

            int i = 0;
            foreach (DataRow row in dtP.Rows)
            {
                listView1.Items.Add(dtP.Rows[i]["Maphong"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Trangthai"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Sl_nguoi"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Loai_phong"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Gia_phong"].ToString());
                switch (listView1.Items[i].SubItems[1].Text)
                {
                    case "Có người":
                        listView1.Items[i].ImageIndex = 1;
                        break;
                    default:
                        listView1.Items[i].ImageIndex = 0;
                        break;
                }
                i++;
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var rectangle = listView1.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    tb_Maphong.Text = listView1.Items[i].Text;
                    tb_GiaP.Text = listView1.Items[i].SubItems[4].Text;
                    tb_LoaiP.Text = listView1.Items[i].SubItems[3].Text;
                    tb_SLN.Text = listView1.Items[i].SubItems[2].Text;
                    tb_Trthai.Text = listView1.Items[i].SubItems[1].Text;
                }

            }
        }

        private void bt_ThemP_Click(object sender, EventArgs e)
        {
            if (CheckP())
            {
                try
                {
                    string sql = "insert into PHONG(Maphong,Sl_nguoi,Loai_phong,Gia_phong) VALUES(@Maphong,@Sl_nguoi,@Loai_phong,@Gia_phong)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@Maphong", SqlDbType.VarChar).Value = tb_Maphong.Text;
                    cmd.Parameters.Add("@Sl_nguoi", SqlDbType.Int).Value = tb_SLN.Text;
                    cmd.Parameters.Add("@Loai_phong", SqlDbType.VarChar).Value = tb_LoaiP.Text;
                    cmd.Parameters.Add("@Gia_phong", SqlDbType.Int).Value = tb_GiaP.Text;
                    cmd.ExecuteNonQuery();
                    daP.Fill(dtP);
                    MessageBox.Show("Thêm phòng thành công, hãy cập nhật lại dữ liệu", "Thông báo");
                    tb_Maphong.Clear();
                    tb_LoaiP.Clear();
                    tb_SLN.Clear();
                    tb_GiaP.Clear();
                    tb_Trthai.Clear();
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại thông tin\n" + loi.Message, "Thông báo");
                }
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bt_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       

        private void bt_CapnhatDL_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM PHONG";
            daP = new SqlDataAdapter(sql, conn);
            dtP = new DataTable();
            UpdatePhong();
            UpdatePhong2();
            listView1.Items.Clear();
            daP.Fill(dtP);
            listView1.View = View.LargeIcon;

            int i = 0;
            foreach (DataRow row in dtP.Rows)
            {
                listView1.Items.Add(dtP.Rows[i]["Maphong"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Trangthai"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Sl_nguoi"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Loai_phong"].ToString());
                listView1.Items[i].SubItems.Add(dtP.Rows[i]["Gia_phong"].ToString());
                switch (listView1.Items[i].SubItems[1].Text)
                {
                    case "Có người":
                        listView1.Items[i].ImageIndex = 1;
                        break;
                    default:
                        listView1.Items[i].ImageIndex = 0;
                        break;
                }
                i++;
            }
        }

        // Đặt phòng
        private void button7_Click(object sender, EventArgs e)
        {
            if (CheckDP())
            {
                try
                {
                    string sql = "INSERT INTO CTDATPHONG VALUES(@Madatphong,@Sl_phong,@Sl_dukien,@Ngay_dp,@Loai_p,@Ngay_dkn,@Ngay_dkt)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@Madatphong", SqlDbType.VarChar).Value = tb_MaDP_DP.Text;
                    cmd.Parameters.Add("@Sl_phong", SqlDbType.Int).Value = tb_SLP.Text;
                    cmd.Parameters.Add("@Sl_dukien", SqlDbType.Int).Value = tb_SLN_DP.Text;
                    cmd.Parameters.Add("@Loai_p", SqlDbType.NVarChar).Value = tb_LoaiP_DP.Text;
                    cmd.Parameters.Add("@Ngay_dkn", SqlDbType.Date).Value = dtp_DKN.Value;
                    cmd.Parameters.Add("@Ngay_dkt", SqlDbType.Date).Value = dtp_DKT.Value;
                    cmd.Parameters.Add("@Ngay_dp", SqlDbType.Date).Value = dtp_DP.Value;
                    cmd.ExecuteNonQuery();
                    dtDP.Clear();
                    daDP.Fill(dtDP);
                    MessageBox.Show("Thêm dữ liệu thành công", "Thông báo");
                    tb_MaDP_DP.Clear();
                    tb_SLP.Clear();
                    tb_SLN_DP.Clear();
                    tb_LoaiP_DP.Clear();
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại thông tin\n" + loi.Message, "Thông báo");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (CheckDP())
            {
                try
                {
                    string sql = "UPDATE CTDATPHONG SET " +
                    "Madatphong=@Madatphong,Sl_phong=@Sl_phong,Sl_dukien=@Sl_dukien,Ngay_dp=@Ngay_dp,Loai_p=@Loai_p,Ngay_dkn=@Ngay_dkn,Ngay_dkt=@Ngay_dkt " +
                    "WHERE Madatphong=@Madatphong";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@Madatphong", SqlDbType.VarChar).Value = tb_MaDP_DP.Text;
                    cmd.Parameters.Add("@Sl_phong", SqlDbType.Int).Value = tb_SLP.Text;
                    cmd.Parameters.Add("@Sl_dukien", SqlDbType.Int).Value = tb_SLN_DP.Text;
                    cmd.Parameters.Add("@Loai_p", SqlDbType.NVarChar).Value = tb_LoaiP_DP.Text;
                    cmd.Parameters.Add("@Ngay_dkn", SqlDbType.Date).Value = dtp_DKN.Value;
                    cmd.Parameters.Add("@Ngay_dkt", SqlDbType.Date).Value = dtp_DKT.Value;
                    cmd.Parameters.Add("@Ngay_dp", SqlDbType.Date).Value = dtp_DP.Value;
                    cmd.ExecuteNonQuery();
                    dtDP.Rows.Clear();
                    daDP.Fill(dtDP);
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo");
                    tb_MaDP_DP.Clear();
                    tb_SLP.Clear();
                    tb_SLN_DP.Clear();
                    tb_LoaiP_DP.Clear();
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại thông tin\n" + loi.Message, "Thông báo");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM CTDATPHONG WHERE Madatphong=@Madatphong";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@Madatphong", SqlDbType.VarChar).Value = tb_MaDP_DP.Text;
                    cmd.ExecuteNonQuery();
                    dtDP.Rows.Clear();
                    daDP.Fill(dtDP);
                    tb_MaDP_DP.Clear();
                    tb_SLP.Clear();
                    tb_SLN_DP.Clear();
                    tb_LoaiP_DP.Clear();
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng kiểm tra lại thông tin\n" + loi.Message, "Thông báo");
                }
            }
        }

        private void dataDPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                tb_SLP.Text = dataDPhong.Rows[index].Cells["Sl_phong"].Value.ToString();
                tb_SLN_DP.Text = dataDPhong.Rows[index].Cells["Sl_dukien"].Value.ToString();
                tb_LoaiP_DP.Text = dataDPhong.Rows[index].Cells["Loai_p"].Value.ToString();
                tb_MaDP_DP.Text = dataDPhong.Rows[index].Cells[0].Value.ToString();
                dtp_DKN.Value = Convert.ToDateTime(dataDPhong.Rows[index].Cells["Ngay_dkn"].Value);
                dtp_DKT.Value = Convert.ToDateTime(dataDPhong.Rows[index].Cells["Ngay_dkt"].Value);
                dtp_DP.Value = Convert.ToDateTime(dataDPhong.Rows[index].Cells["Ngay_dp"].Value);
            }
        }
        //Hóa đơn

        private void bt_Thanhtoan_Click(object sender, EventArgs e)
        {
            SqlDataReader docdl;

            string sql = "select datediff(day,KHACH.Ngay_np,KHACH.Ngay_tp) ,datediff(day,KHACH.Ngay_np,KHACH.Ngay_tp)*PHONG.Gia_phong " +
                "from KHACH inner join PHONG on KHACH.Maphong=PHONG.Maphong " +
                "where KHACH.Maphong='" + tb_Madp_HoaDon.Text + "' and KHACH.Ten_k =N'" + lb_HT_Tenk.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            docdl = cmd.ExecuteReader();
            while (docdl.Read())
            {
                lb_HT_Ngay.Text = docdl[0].ToString();
                lb_HT_Tien.Text = docdl[1].ToString() + " VNĐ";
            }
            docdl.Close();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                lb_HT_Mak.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
                lb_HT_Tenk.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
                lb_HT_Ngay.Text = "";
                lb_HT_Tien.Text = "";
            }
        }
        private void bt_Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_Madp_HoaDon.Text))
            {
                string value = tb_Madp_HoaDon.Text;
                string sql = "SELECT * FROM KHACH WHERE Maphong='" + value + "'";
                daHD = new SqlDataAdapter(sql, conn);
                dtHD = new DataTable();
                daHD.Fill(dtHD);
                dataGridView2.DataSource = dtHD;
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã phòng", "Thông báo");
            }
        }


        // Hàm kiểm tra
        

        private bool Kiemtra() //Hàm kiểm tra nhập thông tin
        {
            if (string.IsNullOrEmpty(tb_Makhach.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng", "Thông báo");
                tb_Makhach.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tb_Ten_k.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên khách hàng", "Thông báo");
                tb_Ten_k.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tb_Sdt_k.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng", "Thông báo");
                tb_Sdt_k.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tb_No_CMND.Text))
            {
                MessageBox.Show("Bạn chưa nhập số CMND/CCCD khách hàng", "Thông báo");
                tb_No_CMND.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cb_Dc.Text))
            {
                MessageBox.Show("Bạn chưa chọn địa chỉ khách hàng", "Thông báo");
                cb_Dc.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cb_DP_Khach.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã đặt phòng", "Thông báo");
                tb_Madp.Focus();
                return false;
            }
            return true;
        }
        private bool Check2()
        {
            if (string.IsNullOrEmpty(tb_MaNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã nhân viên", "Thông báo");
                tb_MaNV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tb_Ten_nv.Text))
            {
                MessageBox.Show("Bạn chưa nhập Tên nhân viên", "Thông báo");
                tb_Ten_nv.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cb_Dc_nv.Text))
            {
                MessageBox.Show("Bạn chưa chọn Địa chỉ", "Thông báo");
                return false;
            }
            if (rd_Nam.Checked == false && rd_Nu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông báo");
                return false;
            }
            if (string.IsNullOrEmpty(tb_SdtNV.Text))
            {
                MessageBox.Show("Bạn chưa nhập Số điện thoại", "Thông báo");
                tb_SdtNV.Focus();
                return false;
            }
            return true;
        }
        private bool CheckP()
        {
            if (string.IsNullOrEmpty(tb_Maphong.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã phòng", "Thông báo");
                tb_Maphong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tb_LoaiP.Text))
            {
                MessageBox.Show("Bạn chưa nhập loại phòng", "Thông báo");
                tb_LoaiP.Focus();
                return false;
            }
            if (!int.TryParse(tb_SLN.Text, out slk))
            {
                MessageBox.Show("Số lượng khách phải là số nguyên", "Thông báo");
                tb_SLN.Focus();
                return false;
            }
            if (!int.TryParse(tb_GiaP.Text, out giaphong))
            {
                MessageBox.Show("Giá phòng phải là số nguyên", "Thông báo");
                tb_GiaP.Focus();
                return false;
            }
            return true;
        }
        private bool CheckDP()
        {
            if (string.IsNullOrEmpty(tb_MaDP_DP.Text))
            {
                MessageBox.Show("Bạn chưa nhập Mã đặt phòng", "Thông báo");
                tb_Madp.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tb_LoaiP_DP.Text))
            {
                MessageBox.Show("Bạn chưa chọn loại phòng", "Thông báo");
                return false;
            }
            if (!int.TryParse(tb_SLP.Text, out slp))
            {
                MessageBox.Show("Số lượng phòng phải là số nguyên");
                tb_SLP.Focus();
                return false;
            }
            if (!int.TryParse(tb_SLN_DP.Text, out sln))
            {
                MessageBox.Show("Số lượng người phải là số nguyên");
                tb_SLN.Focus();
                return false;
            }
            return true;
        }
    }
}
