using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALConfigurationMapper
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
    <Hash>ee18b5e6815fd65e0aa48dcde213b0ad</Hash>
</Codenesium>*/