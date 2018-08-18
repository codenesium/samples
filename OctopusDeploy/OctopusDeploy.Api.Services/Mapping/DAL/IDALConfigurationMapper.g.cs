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
    <Hash>0df966cfd9c5d72176b61cf401709d01</Hash>
</Codenesium>*/