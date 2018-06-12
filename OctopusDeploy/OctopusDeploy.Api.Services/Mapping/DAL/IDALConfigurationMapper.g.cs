using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALConfigurationMapper
        {
                Configuration MapBOToEF(
                        BOConfiguration bo);

                BOConfiguration MapEFToBO(
                        Configuration efConfiguration);

                List<BOConfiguration> MapEFToBO(
                        List<Configuration> records);
        }
}

/*<Codenesium>
    <Hash>1fcc79b54203f6ca53a1e9868b2ee591</Hash>
</Codenesium>*/