using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsrSrvcDAL {
    public class UsrSrvRepository {

        public IDbConnection DbConn { get; private set; }

        public UsrSrvRepository(IDbConnection dbConn) {
            DbConn = dbConn;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>
        ///  result > 0 = UserId
        ///  -1 User Not Valid
        ///  -2 User Inactive
        ///  -3 User Expired
        ///  -4 Password Blocked
        ///  -5 Password Expired
        /// </returns>
        public int validateUser(String userName, String password) {
            int result = 0;

            // sp_validateuser
            using (var cmd = DbConn.CreateCommand()) {
                DbConn.Open();

                cmd.CommandText = "sp_validateuser";
                cmd.CommandType = CommandType.StoredProcedure;

                addParam(cmd, DbType.AnsiString, "@username", userName);
                addParam(cmd, DbType.AnsiString, "@pass", password);

                using (var reader = cmd.ExecuteReader()) {
                    if (reader.Read()) {
                        result = reader.GetInt16(0);
                    } else {
                        throw new Exception("No Result returned by SP " + "sp_validateuser");
                    }
                }
                DbConn.Close();
            }
            return result;
        }


        public void Get(int id) {




        }


        #region Helpers
        private void addParam(IDbCommand cmd, DbType ty, string pName, object val) {
            IDbDataParameter param;

            param = cmd.CreateParameter();
            param.DbType = ty;
            param.ParameterName = pName;
            param.Value = val;
            cmd.Parameters.Add(param);
        }
        #endregion

    }
}
