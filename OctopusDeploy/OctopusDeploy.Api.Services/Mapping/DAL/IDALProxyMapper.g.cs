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
    <Hash>39224eb483d6ee3ebcb65435274000b3</Hash>
</Codenesium>*/