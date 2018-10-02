using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>030876b730adf3f78831fa85259bb915</Hash>
</Codenesium>*/