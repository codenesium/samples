using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
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
    <Hash>d6239f589802751ed2f10cf76936e90f</Hash>
</Codenesium>*/