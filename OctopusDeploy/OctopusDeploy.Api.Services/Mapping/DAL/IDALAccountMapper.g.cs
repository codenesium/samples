using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALAccountMapper
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
    <Hash>5bddb0794d7c5158b9094a461e424d7a</Hash>
</Codenesium>*/