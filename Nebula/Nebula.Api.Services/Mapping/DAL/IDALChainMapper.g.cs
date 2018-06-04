using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IDALChainMapper
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
    <Hash>8ed9708a693bc057fca1d9f1fa6d3912</Hash>
</Codenesium>*/