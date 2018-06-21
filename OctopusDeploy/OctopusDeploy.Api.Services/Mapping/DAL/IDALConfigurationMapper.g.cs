using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>6f2307da18d6f0b3b5349b993076eebe</Hash>
</Codenesium>*/