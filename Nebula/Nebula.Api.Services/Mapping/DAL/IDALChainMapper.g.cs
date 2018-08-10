using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALChainMapper
	{
		Chain MapBOToEF(
			BOChain bo);

		BOChain MapEFToBO(
			Chain efChain);

		List<BOChain> MapEFToBO(
			List<Chain> records);
	}
}

/*<Codenesium>
    <Hash>24f1f3523933e08eeb7e5f0c17d121d1</Hash>
</Codenesium>*/