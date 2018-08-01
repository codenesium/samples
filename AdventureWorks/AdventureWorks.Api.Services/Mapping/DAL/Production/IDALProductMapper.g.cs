using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductMapper
	{
		Product MapBOToEF(
			BOProduct bo);

		BOProduct MapEFToBO(
			Product efProduct);

		List<BOProduct> MapEFToBO(
			List<Product> records);
	}
}

/*<Codenesium>
    <Hash>e4c6a74791cdf539664c9a69fa6e47cc</Hash>
</Codenesium>*/