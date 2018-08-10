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
    <Hash>19357683247d96598921ce71a3328882</Hash>
</Codenesium>*/