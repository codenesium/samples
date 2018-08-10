using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALChainStatusMapper
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
    <Hash>d6b67960f9e44395a9f9db598bee3964</Hash>
</Codenesium>*/