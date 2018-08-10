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
    <Hash>7a19c11f78645f7aa856c83e95001dc1</Hash>
</Codenesium>*/