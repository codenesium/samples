using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>69d4e109af361a3e994b45e582f75a63</Hash>
</Codenesium>*/