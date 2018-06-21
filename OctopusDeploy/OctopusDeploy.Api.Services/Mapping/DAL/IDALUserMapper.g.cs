using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALUserMapper
        {
                User MapBOToEF(
                        BOUser bo);

                BOUser MapEFToBO(
                        User efUser);

                List<BOUser> MapEFToBO(
                        List<User> records);
        }
}

/*<Codenesium>
    <Hash>bbdac505a3d029b87cb712ad94cbd06b</Hash>
</Codenesium>*/