using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductListPriceHistoryMapper
	{
		public virtual void MapDTOToEF(
			int productID,
			DTOProductListPriceHistory dto,
			ProductListPriceHistory efProductListPriceHistory)
		{
			efProductListPriceHistory.SetProperties(
				productID,
				dto.EndDate,
				dto.ListPrice,
				dto.ModifiedDate,
				dto.StartDate);
		}

		public virtual DTOProductListPriceHistory MapEFToDTO(
			ProductListPriceHistory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductListPriceHistory();

			dto.SetProperties(
				ef.ProductID,
				ef.EndDate,
				ef.ListPrice,
				ef.ModifiedDate,
				ef.StartDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>556119e14d98ab800faaaeac8e7baf15</Hash>
</Codenesium>*/