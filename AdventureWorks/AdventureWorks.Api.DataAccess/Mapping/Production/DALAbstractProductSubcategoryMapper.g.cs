using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductSubcategoryMapper
	{
		public virtual void MapDTOToEF(
			int productSubcategoryID,
			DTOProductSubcategory dto,
			ProductSubcategory efProductSubcategory)
		{
			efProductSubcategory.SetProperties(
				productSubcategoryID,
				dto.ModifiedDate,
				dto.Name,
				dto.ProductCategoryID,
				dto.Rowguid);
		}

		public virtual DTOProductSubcategory MapEFToDTO(
			ProductSubcategory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductSubcategory();

			dto.SetProperties(
				ef.ProductSubcategoryID,
				ef.ModifiedDate,
				ef.Name,
				ef.ProductCategoryID,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>f04744037ceb6a62b114811a92ee1eba</Hash>
</Codenesium>*/