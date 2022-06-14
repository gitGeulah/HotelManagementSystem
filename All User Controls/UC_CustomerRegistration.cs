using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagementSystem.All_User_Controls
{
    public partial class UC_CustomerRegistration : UserControl
    {

        function fn = new function();
        String query;

        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(String query, ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while(sdr.Read())
            {
                for(int i = 0; i < sdr.FieldCount; i ++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void txtRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select roomNo from rooms where bed = '" +txtBed.Text+ "' and roomType = '" +txtRoomType.Text+ "' and booked = 'No'";
            setComboBox(query, txtRoomNo);
        }
    }
}
