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
    <Hash>ac36971fe903d3ef15de28a16714828d</Hash>
</Codenesium>*/