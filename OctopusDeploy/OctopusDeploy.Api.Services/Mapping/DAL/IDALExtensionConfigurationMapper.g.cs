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
    <Hash>5906a454d22620133286361cc13c1be7</Hash>
</Codenesium>*/