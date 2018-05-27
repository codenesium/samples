using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductCategoryMapper
	{
		public virtual void MapDTOToEF(
			int productCategoryID,
			DTOProductCategory dto,
			ProductCategory efProductCategory)
		{
			efProductCategory.SetProperties(
				productCategoryID,
				dto.ModifiedDate,
				dto.Name,
				dto.Rowguid);
		}

		public virtual DTOProductCategory MapEFToDTO(
			ProductCategory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductCategory();

			dto.SetProperties(
				ef.ProductCategoryID,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>f8444efe1e20e0d0e35049447705251c</Hash>
</Codenesium>*/