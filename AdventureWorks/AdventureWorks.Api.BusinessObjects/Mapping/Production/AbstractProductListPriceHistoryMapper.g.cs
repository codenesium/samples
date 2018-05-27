using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductListPriceHistoryMapper
	{
		public virtual DTOProductListPriceHistory MapModelToDTO(
			int productID,
			ApiProductListPriceHistoryRequestModel model
			)
		{
			DTOProductListPriceHistory dtoProductListPriceHistory = new DTOProductListPriceHistory();

			dtoProductListPriceHistory.SetProperties(
				productID,
				model.EndDate,
				model.ListPrice,
				model.ModifiedDate,
				model.StartDate);
			return dtoProductListPriceHistory;
		}

		public virtual ApiProductListPriceHistoryResponseModel MapDTOToModel(
			DTOProductListPriceHistory dtoProductListPriceHistory)
		{
			if (dtoProductListPriceHistory == null)
			{
				return null;
			}

			var model = new ApiProductListPriceHistoryResponseModel();

			model.SetProperties(dtoProductListPriceHistory.EndDate, dtoProductListPriceHistory.ListPrice, dtoProductListPriceHistory.ModifiedDate, dtoProductListPriceHistory.ProductID, dtoProductListPriceHistory.StartDate);

			return model;
		}

		public virtual List<ApiProductListPriceHistoryResponseModel> MapDTOToModel(
			List<DTOProductListPriceHistory> dtos)
		{
			List<ApiProductListPriceHistoryResponseModel> response = new List<ApiProductListPriceHistoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9c2270a65effcf6db59b2461d399da1b</Hash>
</Codenesium>*/