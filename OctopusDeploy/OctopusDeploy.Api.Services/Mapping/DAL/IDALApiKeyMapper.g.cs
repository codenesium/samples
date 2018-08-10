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
    <Hash>3162a0909b68b09a635ffdd2ba6bfa8a</Hash>
</Codenesium>*/