using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALTenantMapper
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
    <Hash>0d106cf1156b62ee58605977a4074d76</Hash>
</Codenesium>*/