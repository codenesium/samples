using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public interface IDALLinkMapper
	{
		Link MapBOToEF(
			BOLink bo);

		BOLink MapEFToBO(
			Link efLink);

		List<BOLink> MapEFToBO(
			List<Link> records);
	}
}

/*<Codenesium>
    <Hash>be11603e37aa5ee48a276ffe516c2458</Hash>
</Codenesium>*/