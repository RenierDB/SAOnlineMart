using System.Data;

namespace SAOnlineMart.Models
{
    public class DBLogin
    {
        private Connection _connection { get; set; }
        private bool verified { get; set; }
        private User ?curuser { get; set; }

        public DBLogin()
        {
            _connection = new Connection();
            verified = false;
        }

        public bool getStatus()
        {
            return verified;
        }

        public string getID()
        {
            try
            {
                return curuser?.Id.ToString() ?? throw new Exception("User not verified");
            }
            catch
            {
                throw new Exception("User not verified");
            }
        }

        public string getEmail()
        {
            try
            {
                return curuser?.email ?? throw new Exception("User not verified");
            }
            catch
            {
                throw new Exception("User not verified");
            }
        }

        public string getName()
        {
            try
            {
                return curuser?.name ?? throw new Exception("User not verified"); ;
            }
            catch
            {
                throw new Exception("User not verified");
            }
        }

        public bool verifyUser(string email, string password)
        {
            string query = "SELECT * FROM account WHERE account_email = '" + email + "' AND account_password = '" + password + "'";
            DataTable data = _connection.queryDB(query);
            if (data.Rows.Count > 0)
            {
                verified = true;
                int id = (int)data.Rows[0]["account_id"];
                string name = (string)data.Rows[0]["account_name"];
                string mail = (string)data.Rows[0]["account_email"];
                curuser = new User(id, name, mail);
                return true;
            }
            return false;
        }
    }
}
