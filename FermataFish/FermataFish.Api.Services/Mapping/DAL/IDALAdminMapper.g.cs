using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALAdminMapper
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
    <Hash>dc2bd9c7c796849b1fd2a2148b13f5d7</Hash>
</Codenesium>*/