using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALUserRoleMapper
        {
                UserRole MapBOToEF(
                        BOUserRole bo);

                BOUserRole MapEFToBO(
                        UserRole efUserRole);

                List<BOUserRole> MapEFToBO(
                        List<UserRole> records);
        }
}

/*<Codenesium>
    <Hash>75855e9c5ce97a4eb46a1b945a9f67c8</Hash>
</Codenesium>*/