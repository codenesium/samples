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
    <Hash>1e25ac999de49b8402ecb3f4e9ce4b16</Hash>
</Codenesium>*/