using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductListPriceHistoryMapper
	{
		public virtual BOProductListPriceHistory MapModelToBO(
			int productID,
			ApiProductListPriceHistoryRequestModel model
			)
		{
			BOProductListPriceHistory boProductListPriceHistory = new BOProductListPriceHistory();

			boProductListPriceHistory.SetProperties(
				productID,
				model.EndDate,
				model.ListPrice,
				model.ModifiedDate,
				model.StartDate);
			return boProductListPriceHistory;
		}

		public virtual ApiProductListPriceHistoryResponseModel MapBOToModel(
			BOProductListPriceHistory boProductListPriceHistory)
		{
			var model = new ApiProductListPriceHistoryResponseModel();

			model.SetProperties(boProductListPriceHistory.EndDate, boProductListPriceHistory.ListPrice, boProductListPriceHistory.ModifiedDate, boProductListPriceHistory.ProductID, boProductListPriceHistory.StartDate);

			return model;
		}

		public virtual List<ApiProductListPriceHistoryResponseModel> MapBOToModel(
			List<BOProductListPriceHistory> items)
		{
			List<ApiProductListPriceHistoryResponseModel> response = new List<ApiProductListPriceHistoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b070932a29a12a88d3fbefaafe139e08</Hash>
</Codenesium>*/