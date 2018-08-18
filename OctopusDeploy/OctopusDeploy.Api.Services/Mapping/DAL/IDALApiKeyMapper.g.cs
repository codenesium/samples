using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALApiKeyMapper
	{
		ApiKey MapBOToEF(
			BOApiKey bo);

		BOApiKey MapEFToBO(
			ApiKey efApiKey);

		List<BOApiKey> MapEFToBO(
			List<ApiKey> records);
	}
}

/*<Codenesium>
    <Hash>12f88bc77c4b23e0d3f745098399d04d</Hash>
</Codenesium>*/