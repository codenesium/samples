using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductModelMapper
	{
		public virtual void MapDTOToEF(
			int productModelID,
			DTOProductModel dto,
			ProductModel efProductModel)
		{
			efProductModel.SetProperties(
				productModelID,
				dto.CatalogDescription,
				dto.Instructions,
				dto.ModifiedDate,
				dto.Name,
				dto.Rowguid);
		}

		public virtual DTOProductModel MapEFToDTO(
			ProductModel ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductModel();

			dto.SetProperties(
				ef.ProductModelID,
				ef.CatalogDescription,
				ef.Instructions,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>bfb6fb0897a7ef4c70e55851a7a095a6</Hash>
</Codenesium>*/