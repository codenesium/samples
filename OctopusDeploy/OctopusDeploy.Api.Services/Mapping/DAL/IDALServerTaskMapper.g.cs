using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>d4372350ade33b20bf3979a15a9d0923</Hash>
</Codenesium>*/