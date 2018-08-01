using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALProductInventoryMapper
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
    <Hash>b0ad14353d0a809b95ecdea49768c918</Hash>
</Codenesium>*/