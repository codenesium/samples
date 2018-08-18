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
    <Hash>19e09a4103dd5557d403226db18547a3</Hash>
</Codenesium>*/