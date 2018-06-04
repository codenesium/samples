using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>3b7fd0efe882ffaf0768f4e2e6f0e802</Hash>
</Codenesium>*/