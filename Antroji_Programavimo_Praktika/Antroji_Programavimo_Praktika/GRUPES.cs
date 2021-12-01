using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Antroji_Programavimo_Praktika
{
    class GRUPES
    {
        MY_DB db = new MY_DB();
        public bool insertGrupe(string fngrupe)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `grupe`(`grupespav`) VALUES (@gr)", db.GetConnection);
            //  @fn,@ln,@name,@pas

            command.Parameters.Add("@gr", MySqlDbType.VarChar).Value = fngrupe;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool deleteGrupe(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `grupe` WHERE `id`=@studentID", db.GetConnection);

            //  @ID

            command.Parameters.Add("@studentID", MySqlDbType.Int32).Value = id;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

    }
}
