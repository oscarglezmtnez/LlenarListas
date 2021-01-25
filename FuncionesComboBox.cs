using System;
using System.Windows.Forms;
using System.Data.OleDb;


namespace BibliotecaDeFunciones
{
    /// <summary>
    /// Se ha modificado este fichero en el repositorio local
    /// </summary>
    public class FuncionesComboBox
    {
        public void RellenarComboBox(ComboBox cbb, string selectCmd, string cadenadeconexion)
        {
            cbb.Items.Clear();
            OleDbConnection cnx = new OleDbConnection(cadenadeconexion);
            try
            {
                cnx.Open();
                OleDbCommand cmd = new OleDbCommand(selectCmd, cnx);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbb.Items.Add(dr[0].ToString().ToUpper());
                }

                cnx.Close();
                cbb.Items.Insert(0, "---> Selecciona un item");
                cbb.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
