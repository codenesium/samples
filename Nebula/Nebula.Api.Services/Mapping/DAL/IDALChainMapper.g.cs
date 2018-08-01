using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>206e4c20cce8f9f7a797f42521e42b7d</Hash>
</Codenesium>*/