using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALAdminMapper
	{
		Admin MapBOToEF(
			BOAdmin bo);

		BOAdmin MapEFToBO(
			Admin efAdmin);

		List<BOAdmin> MapEFToBO(
			List<Admin> records);
	}
}

/*<Codenesium>
    <Hash>848423aa6be1b6b347fc9183e7ec410f</Hash>
</Codenesium>*/