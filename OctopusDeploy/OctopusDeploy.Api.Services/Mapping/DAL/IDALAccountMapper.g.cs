using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALAccountMapper
	{
		Account MapBOToEF(
			BOAccount bo);

		BOAccount MapEFToBO(
			Account efAccount);

		List<BOAccount> MapEFToBO(
			List<Account> records);
	}
}

/*<Codenesium>
    <Hash>27db27d9957dcbb2fe73a254a313e8c9</Hash>
</Codenesium>*/