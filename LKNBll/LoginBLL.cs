using LKNDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LKNBll
{
   public  class LoginBLL
    {
       LoginDal dal = new LoginDal();
        public bool LoginCheck(string loginName,string loginPwd)
       {
          return  dal.LoginCheck(loginName, loginPwd)>0;
       }
    }
}
