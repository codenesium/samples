using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>d378f4a464edc7dc671c196b08fc50b2</Hash>
</Codenesium>*/