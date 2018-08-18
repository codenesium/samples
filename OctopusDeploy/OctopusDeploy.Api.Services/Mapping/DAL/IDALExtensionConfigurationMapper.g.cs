using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALExtensionConfigurationMapper
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
    <Hash>12ed1c8b613bcf460315a511e8b5bab0</Hash>
</Codenesium>*/