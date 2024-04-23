using InterferenteECO.DataAccess;
using InterferenteECO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterferenteECO.Forms
{
    public partial class Logare : Form
    {
        public Logare()
        {
            InitializeComponent();
        }

        private void Logare_Load(object sender, EventArgs e)
        {
            parolaTextBox.Text = "eco";

            DatabaseHelper.InsertUsers();
            List<string> users = DatabaseHelper.GetUsers();
            foreach(string s in users)
            {
                usersComboBox.Items.Add(s);
            }
            usersComboBox.SelectedIndex = 1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            UserModel user = new UserModel();
            if (usersComboBox.SelectedItem != null)
            {
                user.UserName = usersComboBox.SelectedItem.ToString();
                user.Password = parolaTextBox.Text;
            }
            else { MessageBox.Show("Alegeti un utilizator!"); }
            if(DatabaseHelper.IsUser(user))
            {
                InterferenteECO interferenteECO = new InterferenteECO();
                interferenteECO.username = user.UserName.Trim();
                interferenteECO.background = pictureBox.Image;
                this.Hide();
                interferenteECO.ShowDialog();
                this.Show();
            }else
            {
                MessageBox.Show("Reintroduceti parola!");
                parolaTextBox.Text = "";
            }
        }
    }
}
