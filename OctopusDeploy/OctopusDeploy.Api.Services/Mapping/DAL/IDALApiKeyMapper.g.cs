using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALApiKeyMapper
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
    <Hash>b9c6079805b76077b4854bbf1d25d6fa</Hash>
</Codenesium>*/