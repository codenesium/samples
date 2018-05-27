using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductCostHistoryMapper
	{
		public virtual void MapDTOToEF(
			int productID,
			DTOProductCostHistory dto,
			ProductCostHistory efProductCostHistory)
		{
			efProductCostHistory.SetProperties(
				productID,
				dto.EndDate,
				dto.ModifiedDate,
				dto.StandardCost,
				dto.StartDate);
		}

		public virtual DTOProductCostHistory MapEFToDTO(
			ProductCostHistory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductCostHistory();

			dto.SetProperties(
				ef.ProductID,
				ef.EndDate,
				ef.ModifiedDate,
				ef.StandardCost,
				ef.StartDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>48f071e6e114168fbea55747cabb6e6b</Hash>
</Codenesium>*/