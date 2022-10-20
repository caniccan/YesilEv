using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.Core.Context;
using YesilEvV2.Core.Entities;
using YesilEvV2.Core.Repos;

namespace YesilEvV2.DAL.Concrete
{
    public class RolDAL : EFRepoBase<MyDbContext, Rol>
    {
        public RolDAL()
        {

        }
        public RolDAL(MyDbContext context): base(context)
        {

        }
    }
}
