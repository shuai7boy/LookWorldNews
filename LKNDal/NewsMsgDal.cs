using LKNModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using 三层__登录;

namespace LKNDal
{
    public class NewsMsgDal
    {
        //增加 查找
        public int Add(WorldNews news)
        {
            string sql = "insert into NewsMsg values(@title,@author,@time,@imgUrl,@content,@detailUrl,@biaoShi);";
            SqlParameter[] pms=new SqlParameter[]{
                new SqlParameter("@title",SqlDbType.NVarChar,20){Value=news.Title},
                new SqlParameter("@author",SqlDbType.NVarChar,8){Value=news.Author},
                new SqlParameter("@time",SqlDbType.Date){Value=news.SendTime},
                new SqlParameter("@imgUrl",SqlDbType.NVarChar){Value=news.ImgUrl},
                new SqlParameter("@content",SqlDbType.NVarChar){Value=news.Content},
                new SqlParameter("@detailUrl",SqlDbType.NVarChar){Value=news.DetailUrl},
                new SqlParameter("@biaoShi",SqlDbType.Int){Value=news.BiaoShi}

            };
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, pms);
        }
        //根据条件查找分页数据
        public List<WorldNews> SelectPageMsg(int pageIndex,int pageSize,int bs,out int recordCount,out int pageCount)
        {
            string sql = "usp_News";
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@pageIndex",SqlDbType.Int){Value=pageIndex},
                new SqlParameter("@pageSize",SqlDbType.Int){Value=pageSize},
                new SqlParameter("@bsId",SqlDbType.Int){Value=bs},
                new SqlParameter("@recordCount",SqlDbType.Int){Direction=ParameterDirection.Output},
                new SqlParameter("@pageCount",SqlDbType.Int){Direction=ParameterDirection.Output}
            };
            List<WorldNews> list = new List<WorldNews>();
            using (SqlDataReader reader=SqlHelper.ExecuteReader(sql,CommandType.StoredProcedure,pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        WorldNews w = new WorldNews();
                        w.NId = reader.GetInt32(0);
                        w.Title = reader.GetString(1);
                        w.Author = reader.GetString(2);
                        w.SendTime = reader.GetDateTime(3);
                        w.ImgUrl = reader.GetString(4);
                        w.Content = reader.GetString(5);
                        w.DetailUrl = reader.GetString(6);
                        w.BiaoShi = reader.GetInt32(7);
                        list.Add(w);
                    }
                }
            }
            recordCount = Convert.ToInt32(pms[3].Value);
            pageCount = Convert.ToInt32(pms[4].Value);
            return list;
        }
    }
}
