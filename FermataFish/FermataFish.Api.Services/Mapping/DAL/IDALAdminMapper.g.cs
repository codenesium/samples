using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>0b9140aa41996e4db6ac7b33b6bf3df1</Hash>
</Codenesium>*/