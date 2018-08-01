using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALUserRoleMapper
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
    <Hash>0da292ad37557499fd3a01178828e228</Hash>
</Codenesium>*/