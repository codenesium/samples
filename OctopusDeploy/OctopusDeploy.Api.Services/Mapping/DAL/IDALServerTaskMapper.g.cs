using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALServerTaskMapper
        {
                ServerTask MapBOToEF(
                        BOServerTask bo);

                BOServerTask MapEFToBO(
                        ServerTask efServerTask);

                List<BOServerTask> MapEFToBO(
                        List<ServerTask> records);
        }
}

/*<Codenesium>
    <Hash>1c7973c285558712c04ad2bb1f552733</Hash>
</Codenesium>*/