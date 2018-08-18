using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALUserRoleMapper
	{
		UserRole MapBOToEF(
			BOUserRole bo);

		BOUserRole MapEFToBO(
			UserRole efUserRole);

		List<BOUserRole> MapEFToBO(
			List<UserRole> records);
	}
}

/*<Codenesium>
    <Hash>c090999785aa3561b582d3ccc11748b2</Hash>
</Codenesium>*/