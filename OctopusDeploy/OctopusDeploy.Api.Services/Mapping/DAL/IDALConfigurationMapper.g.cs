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
    <Hash>9cf0b219655d2b9acb905e9a751d056c</Hash>
</Codenesium>*/