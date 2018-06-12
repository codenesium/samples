using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALExtensionConfigurationMapper
        {
                ExtensionConfiguration MapBOToEF(
                        BOExtensionConfiguration bo);

                BOExtensionConfiguration MapEFToBO(
                        ExtensionConfiguration efExtensionConfiguration);

                List<BOExtensionConfiguration> MapEFToBO(
                        List<ExtensionConfiguration> records);
        }
}

/*<Codenesium>
    <Hash>4022a0987e99c87cb435249c4c2578a2</Hash>
</Codenesium>*/