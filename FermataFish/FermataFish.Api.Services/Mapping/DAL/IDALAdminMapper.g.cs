using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALAdminMapper
        {
                Admin MapBOToEF(
                        BOAdmin bo);

                BOAdmin MapEFToBO(
                        Admin efAdmin);

                List<BOAdmin> MapEFToBO(
                        List<Admin> records);
        }
}

/*<Codenesium>
    <Hash>0a0a5ba471be9a4a500e4fa4943fbf63</Hash>
</Codenesium>*/