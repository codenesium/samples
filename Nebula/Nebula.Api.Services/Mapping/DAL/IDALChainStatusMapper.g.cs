using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
    <Hash>8efb7645f48b000729e72731f897e28a</Hash>
</Codenesium>*/