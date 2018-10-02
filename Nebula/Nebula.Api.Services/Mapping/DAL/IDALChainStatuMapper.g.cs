using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALChainStatuMapper
	{
		ChainStatu MapBOToEF(
			BOChainStatu bo);

		BOChainStatu MapEFToBO(
			ChainStatu efChainStatu);

		List<BOChainStatu> MapEFToBO(
			List<ChainStatu> records);
	}
}

/*<Codenesium>
    <Hash>567b79f75c11d6c5459d3b8b84237500</Hash>
</Codenesium>*/