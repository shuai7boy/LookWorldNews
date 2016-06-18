using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using 三层__登录;

namespace LKNDal
{
    public class LoginDal
    {
        public int LoginCheck(string loginName,string loginPwd)
        {
            string sql = "select count(*) from LoginCheck where LoginName=@name and LoginPwd=@pwd;";
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.NVarChar,20){Value=loginName},
                new SqlParameter("@pwd",SqlDbType.NVarChar,40){Value=loginPwd}
            };
           return Convert.ToInt32(SqlHelper.ExecuteScalar(sql, CommandType.Text, pms));
        }
    }
}
