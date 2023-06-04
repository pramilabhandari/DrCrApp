﻿using Dapper;
using Helper.Dapper;
using Models.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class LoginService:Interfacelogin
    {

        public async Task<dynamic> Login(Login l) // a request
        {
            var res = new ResponseValues(); //model class ko obj pass to res(response variable)
            if (l.Status != "")
            {
                res.Values = null;
                res.StatusCode = 400;
                res.Message = " l is empty";
            }
            else
            {
                var sql = "sp_login"; // var is data type not integer "sp_blog" is store procedure name.
                var parameters = new DynamicParameters(); // this is inbuilt class(Dapper ko class) yo class store procedure ma parameter pathauana use hunxa. so yasko obj refrence variable ma pathako
                parameters.Add("@flag", ""); // model ma banako prop(req) lai service bata server ma pathauna @ use garne
                parameters.Add("@primary", l); // it add @primary property to the parameters
                parameters.Add("@UserName", "");
                parameters.Add("@Password", "");




                var data = await DbHelper.RunProc<dynamic>(sql, parameters); // it run the stored procedure with the help of DbHelper and pass result to the data.
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.Values = data.ToList();
                    res.StatusCode = 200;
                    res.Message = "Success";

                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.Values = null;
                    res.StatusCode = data.FirstOrDefault().Message.StatusCode;
                    res.Message = data.FirstOrDefault().Message;

                }
                else
                {
                    res.Values = null;
                    res.StatusCode = 400;
                    res.Message = "no data";

                }
            }
            return res;
        }

    }

    public class Interfacelogin
    {
    }
}
