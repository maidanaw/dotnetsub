﻿using Core.Context;
using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class AlertRepository : GenericRepository<Alert>, IAlertRepository
    {
        public AlertRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
