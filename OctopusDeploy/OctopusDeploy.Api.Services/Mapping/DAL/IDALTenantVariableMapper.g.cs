using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALTenantVariableMapper
	{
		TenantVariable MapBOToEF(
			BOTenantVariable bo);

		BOTenantVariable MapEFToBO(
			TenantVariable efTenantVariable);

		List<BOTenantVariable> MapEFToBO(
			List<TenantVariable> records);
	}
}

/*<Codenesium>
    <Hash>1f635ced23ae77658d54a216673c9318</Hash>
</Codenesium>*/