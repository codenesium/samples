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
    <Hash>4959227e73d65f6dac373c4c3b9f7297</Hash>
</Codenesium>*/