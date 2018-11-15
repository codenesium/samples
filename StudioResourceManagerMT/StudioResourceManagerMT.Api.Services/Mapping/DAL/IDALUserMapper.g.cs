using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>41934be7a1d4218723e167496b088063</Hash>
</Codenesium>*/