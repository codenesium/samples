using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALUserMapper
	{
		User MapBOToEF(
			BOUser bo);

		BOUser MapEFToBO(
			User efUser);

		List<BOUser> MapEFToBO(
			List<User> records);
	}
}

/*<Codenesium>
    <Hash>ea16a687217f8d5a94282e5a4c55f6aa</Hash>
</Codenesium>*/