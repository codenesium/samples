using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALProductInventoryMapper
	{
		void MapDTOToEF(
			int productID,
			DTOProductInventory dto,
			ProductInventory efProductInventory);

		DTOProductInventory MapEFToDTO(
			ProductInventory efProductInventory);
	}
}

/*<Codenesium>
    <Hash>6054ccfbb8f845f4583037731803df3c</Hash>
</Codenesium>*/