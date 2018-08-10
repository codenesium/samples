using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALProxyMapper
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
    <Hash>ea942ea452513b4a5e66dd6b3db5467f</Hash>
</Codenesium>*/