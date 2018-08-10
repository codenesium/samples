using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALUserMapper
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
    <Hash>e23d0854a1744c9ccea00d042bcdec3b</Hash>
</Codenesium>*/