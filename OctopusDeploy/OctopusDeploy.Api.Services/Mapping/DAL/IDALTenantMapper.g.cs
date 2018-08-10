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
    <Hash>8c50bc47ca6541c75424f8abec56cb52</Hash>
</Codenesium>*/