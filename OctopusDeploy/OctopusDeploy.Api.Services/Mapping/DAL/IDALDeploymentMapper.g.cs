using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALDeploymentMapper
        {
                Deployment MapBOToEF(
                        BODeployment bo);

                BODeployment MapEFToBO(
                        Deployment efDeployment);

                List<BODeployment> MapEFToBO(
                        List<Deployment> records);
        }
}

/*<Codenesium>
    <Hash>4b23c245ee91105b6e8211320fa17e27</Hash>
</Codenesium>*/