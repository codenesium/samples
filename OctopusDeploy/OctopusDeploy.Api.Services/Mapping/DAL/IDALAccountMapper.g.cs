using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALAccountMapper
        {
                Account MapBOToEF(
                        BOAccount bo);

                BOAccount MapEFToBO(
                        Account efAccount);

                List<BOAccount> MapEFToBO(
                        List<Account> records);
        }
}

/*<Codenesium>
    <Hash>441bce71d2cad0569cab934b32a16216</Hash>
</Codenesium>*/