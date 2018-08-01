using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALTenantVariableMapper
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
    <Hash>fa77f6bf805bc980010b5508eafaa9bc</Hash>
</Codenesium>*/