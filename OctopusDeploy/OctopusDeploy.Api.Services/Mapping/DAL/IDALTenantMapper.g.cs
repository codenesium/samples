using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALTenantMapper
	{
		Tenant MapBOToEF(
			BOTenant bo);

		BOTenant MapEFToBO(
			Tenant efTenant);

		List<BOTenant> MapEFToBO(
			List<Tenant> records);
	}
}

/*<Codenesium>
    <Hash>435fe851dbf229076811a01d57a09ac6</Hash>
</Codenesium>*/