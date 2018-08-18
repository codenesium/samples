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
    <Hash>b89b85eb0213327b9f8714a81d56748c</Hash>
</Codenesium>*/