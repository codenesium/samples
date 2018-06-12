using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>3813c457650af4a11e74329e9a848e75</Hash>
</Codenesium>*/