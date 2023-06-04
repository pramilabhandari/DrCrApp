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
    public class UserService:InterfaceUser
    {
        public async Task<dynamic> CreateUser(User u) // a request
        {
            var res = new ResponseValues(); //model class ko obj pass to res(response variable)
            if (u.Status != "")
            {
                res.Values = null;
                res.StatusCode = 400;
                res.Message = " u is empty";
            }
            else
            {
                var sql = "sp_user"; // var is data type not integer "sp_blog" is store procedure name.
                var parameters = new DynamicParameters(); // this is inbuilt class(Dapper ko class) yo class store procedure ma parameter pathauana use hunxa. so yasko obj refrence variable ma pathako
                parameters.Add("@flag", u.Flag); // model ma banako prop(req) lai service bata server ma pathauna @ use garne
                parameters.Add("@primary", u); // it add @primary property to the parameters
                parameters.Add("@UserName", u.UserName);
                parameters.Add("@Password", u.Password);
                parameters.Add("@IsActive", u.IsActive);
                parameters.Add("@Name", u.Name);





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

    public class InterfaceUser
    {
    }
}

