﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Context;
using YesilEvV2.Core.Entities;
using YesilEvV2.Core.Repos;
using YesilEvV2.DAL.Interfaces;
using YesilEvV2.DTOs;
using YesilEvV2.Mapping;

namespace YesilEvV2.DAL.Concrete
{
    public class FavorilerDAL : EFRepoBase<MyDbContext, Favori>
    {
        public FavorilerDAL()
        {

        }
        public FavorilerDAL(MyDbContext context) : base(context)
        {

        }
    }
}
