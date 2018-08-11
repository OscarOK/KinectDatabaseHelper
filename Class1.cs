using System;
using Npgsql;

namespace KinectDatabaseHelper
{
    public class DatabaseHelper
    {
        // Class attributes
        public string Host { set; get; }
        public string User { set; get; }
        public string DBname { set; get; }
        public string Password { set; get; }
        public string Port { set; get; }

        private string _tablename;
        private NpgsqlConnection _conn;

        public string TableName
        {
            set
            {
                if (value.Trim().Contains(" "))
                {
                    throw new ArgumentException("Invalid table name");
                }

                this._tablename = value.Trim();
            }

            get { return this._tablename; }
        }

        public DatabaseHelper(string tableName, string password)
        {
            TableName = tableName;
            Password = password;
            Host = "localhost";
            User = "postgres";
            DBname = "postgres";
            Port = "5432";
        }

        private string GetConnectionString()
        {
            return string.Format(
                "Server={0}; User Id={1}; Database={2}; Port={3}; Password={4};",
                Host, User, DBname, Port, Password
                );
        }

        public bool TryConnection()
        {
            _conn = new NpgsqlConnection(GetConnectionString());

            try
            {
                _conn.Open();
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool CloseConnection()
        {
            if (_conn == null)
            {
                return false;
            }
            
            _conn.Close();
            return true;
        }
        
        private void Comm(string strCommand)
        {
            TryConnection();
            var command = new NpgsqlCommand(strCommand, _conn);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void CreateTable()
        {
            var strCommand = "CREATE TABLE IF NOT EXISTS " + TableName + " (" +
                             "body_id text, time timestamp without time zone DEFAULT CURRENT_TIMESTAMP," +
                             "ankleleft_x real, ankleleft_y real, ankleleft_z real," +
                             "ankleright_x real, ankleright_y real, ankleright_z real," +
                             "elbowleft_x real, elbowleft_y real, elbowleft_z real," +
                             "elbowright_x real, elbowright_y real, elbowright_z real," +
                             "footleft_x real, footleft_y real, footleft_z real," +
                             "footright_x real, footright_y real, footright_z real," +
                             "handleft_x real, handleft_y real, handleft_z real," +
                             "handright_x real, handright_y real, handright_z real," +
                             "handtipleft_x real, handtipleft_y real, handtipleft_z real," +
                             "handtipright_x real, handtipright_y real, handtipright_z real," +
                             "head_x real, head_y real, head_z real," +
                             "hipleft_x real, hipleft_y real, hipleft_z real," +
                             "hipright_x real, hipright_y real, hipright_z real," +
                             "kneeleft_x real, kneeleft_y real, kneeleft_z real," +
                             "kneeright_x real, kneeright_y real, kneeright_z real," +
                             "neck_x real, neck_y real, neck_z real," +
                             "shoulderleft_x real, shoulderleft_y real, shoulderleft_z real," +
                             "shoulderright_x real, shoulderright_y real, shoulderright_z real," +
                             "spinebase_x real, spinebase_y real, spinebase_z real," +
                             "spinemid_x real, spinemid_y real, spinemid_z real," +
                             "spineshoulder_x real, spineshoulder_y real, spineshoulder_z real," +
                             "thumbleft_x real, thumbleft_y real, thumbleft_z real," +
                             "thumbright_x real, thumbright_y real, thumbright_z real," +
                             "wristleft_x real, wristleft_y real, wristleft_z real," +
                             "wristright_x real, wristright_y real, wristright_z real" +
                             ");";

            Comm(strCommand);
        }

        public void ClearTable()
        {
            var strCommand = "TRUNCATE TABLE " + TableName + ";";
            Comm(strCommand);
        }

        public void DropTable()
        {
            var strCommand = "DROP TABLE IF EXISTS " + TableName + ";";
            Comm(strCommand);
        }
        
        
    }
}