﻿using Service.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUnitOfWork
    {

        LoginService LoginService { get; }
        ReferenceService ReferenceService { get; set; }
        UserService userService { get; set; }
    }
}
