using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALProxyMapper
	{
		Proxy MapBOToEF(
			BOProxy bo);

		BOProxy MapEFToBO(
			Proxy efProxy);

		List<BOProxy> MapEFToBO(
			List<Proxy> records);
	}
}

/*<Codenesium>
    <Hash>7ae81e0d40cd5aeebdcb62936de5b066</Hash>
</Codenesium>*/