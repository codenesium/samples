using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IDALChainStatusMapper
	{
		ChainStatus MapBOToEF(
			BOChainStatus bo);

		BOChainStatus MapEFToBO(
			ChainStatus efChainStatus);

		List<BOChainStatus> MapEFToBO(
			List<ChainStatus> records);
	}
}

/*<Codenesium>
    <Hash>682091e912c24d6a81e0a6f53fa37353</Hash>
</Codenesium>*/