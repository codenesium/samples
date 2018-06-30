using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>5abbfb92b9aac5d6d7a32f912ec2a78e</Hash>
</Codenesium>*/