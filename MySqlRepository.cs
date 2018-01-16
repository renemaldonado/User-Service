using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LMSUsrSrvcDAL {
    public class MySqlRepository : IRepository<TEntity> {

        protected readonly MySqlConnection DBConn;

        public MySqlRepository(MySqlConnection dbConn) {
            DBConn = dbConn;
        }



    }
}
