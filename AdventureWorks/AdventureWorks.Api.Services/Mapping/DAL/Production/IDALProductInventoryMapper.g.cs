using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductInventoryMapper
	{
		ProductInventory MapBOToEF(
			BOProductInventory bo);

		BOProductInventory MapEFToBO(
			ProductInventory efProductInventory);

		List<BOProductInventory> MapEFToBO(
			List<ProductInventory> records);
	}
}

/*<Codenesium>
    <Hash>6bca36a15d648f45c2f5281d9639f844</Hash>
</Codenesium>*/