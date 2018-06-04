using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>65528440945b562db64720a8950c82c2</Hash>
</Codenesium>*/