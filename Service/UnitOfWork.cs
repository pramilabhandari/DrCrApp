using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service;
using Models.Model;
using Dapper;
using Service.Interface;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    public class UnitOfWork:IUnitOfWork
    {
        public UnitOfWork(IConfiguration config)
        {
            Configuration = config;
        }


        public LoginService LoginService => new LoginService();





        // for getting value from appsetting.json
        private IConfiguration Configuration { get; }

      



    }
}
