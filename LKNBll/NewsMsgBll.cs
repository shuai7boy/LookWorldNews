using LKNDal;
using LKNModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKNBll
{    
    public  class NewsMsgBll
    {
        NewsMsgDal dal = new NewsMsgDal();
        
        //增加 查找
        public bool Add(WorldNews news)
        {
            return dal.Add(news)>0;
        }
        public List<WorldNews> SelectPageMsg(int pageIndex, int pageSize,int bs,out int recordCount, out int pageCount)
        {
            return dal.SelectPageMsg(pageIndex, pageSize,bs,out  recordCount, out pageCount);
        }

    }
}
