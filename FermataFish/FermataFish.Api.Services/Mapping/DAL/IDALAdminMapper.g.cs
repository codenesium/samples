using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>7e3b40f52df67f26ce130f30a196f60d</Hash>
</Codenesium>*/