using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
    <Hash>b5228b871dac93d8dc76614a39864eb2</Hash>
</Codenesium>*/