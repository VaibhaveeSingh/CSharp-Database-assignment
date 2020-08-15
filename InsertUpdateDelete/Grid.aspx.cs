using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace InsertUpdateDelete
{
    public partial class Grid : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OOV082L\MSSQLSERVER02;Initial Catalog=albums;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public void ShowGridChart()
        {
            conn.Open();
            cmd = new SqlCommand("select * from records",conn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            dr.Close();
            conn.Close();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGridChart();
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insertRecord", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = txtTitle.Text;
            cmd.Parameters.Add("@artistName", SqlDbType.VarChar, 20).Value = txtArtist.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGridChart();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("DELETE FROM records where sNo=@sno", conn);
            cmd.Parameters.Add("@sno", SqlDbType.Int).Value = Convert.ToInt32(txtSNo.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("alert(one row updated)");
            }
            conn.Close();
            ShowGridChart();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert	into records (Title,artistName) values ('" + txtTitle.Text + "', '" + txtArtist.Text + "')", conn);
            int x = cmd.ExecuteNonQuery();
            conn.Close();
            ShowGridChart();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //cmd = new SqlCommand("update records set Title='" + txtTitle.Text + "' ,artistName='" + txtArtist.Text + "' where sNo=" + txtSNo.Text + " ", conn);
            //int x = cmd.ExecuteNonQuery();
            //conn.Close();
            //ShowGridChart();
        }

        protected void btnInsPrm_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("insert	into records (Title,artistName) values ( @title, @artistname)", conn);
            cmd.Parameters.Add("@title", SqlDbType.VarChar,50).Value = txtTitle.Text;
            cmd.Parameters.Add("@artistname", SqlDbType.VarChar, 20).Value = txtArtist.Text;
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGridChart();
        }

        protected void btnUpdPrm_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("update records set Title=@title ,artistName=@artistname where sNo=@sno", conn);
            cmd.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = txtTitle.Text;
            cmd.Parameters.Add("@artistname", SqlDbType.VarChar, 20).Value = txtArtist.Text;
            cmd.Parameters.Add("@sno", SqlDbType.Int).Value =Convert.ToInt32(txtSNo.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("alert(one row updated)");
            }
            conn.Close();
            ShowGridChart();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("DELETE FROM records WHERE sNo=" + txtSNo.Text + " ", conn);
            int x = cmd.ExecuteNonQuery();
            conn.Close();
            ShowGridChart();
        }

        protected void btnDelSP_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("deleteRecord", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sno", SqlDbType.Int).Value = Convert.ToInt32(txtSNo.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void btnUpdSP_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("UpdateRecord", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@title", SqlDbType.VarChar, 50).Value = txtTitle.Text;
            cmd.Parameters.Add("@artistname", SqlDbType.VarChar, 20).Value = txtArtist.Text;
            cmd.Parameters.Add("@sno", SqlDbType.Int).Value = Convert.ToInt32(txtSNo.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGridChart();
        }
    }
}