﻿using CallCenter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Core.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Departments> GetDepartments();
    }
}
