using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductInventoryMapper
	{
		public virtual void MapDTOToEF(
			int productID,
			DTOProductInventory dto,
			ProductInventory efProductInventory)
		{
			efProductInventory.SetProperties(
				productID,
				dto.Bin,
				dto.LocationID,
				dto.ModifiedDate,
				dto.Quantity,
				dto.Rowguid,
				dto.Shelf);
		}

		public virtual DTOProductInventory MapEFToDTO(
			ProductInventory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductInventory();

			dto.SetProperties(
				ef.ProductID,
				ef.Bin,
				ef.LocationID,
				ef.ModifiedDate,
				ef.Quantity,
				ef.Rowguid,
				ef.Shelf);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>9090d0a182ac60134a4a593c1b46f2ea</Hash>
</Codenesium>*/