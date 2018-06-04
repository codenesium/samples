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
			BOProductListPriceHistory BOProductListPriceHistory = new BOProductListPriceHistory();

			BOProductListPriceHistory.SetProperties(
				productID,
				model.EndDate,
				model.ListPrice,
				model.ModifiedDate,
				model.StartDate);
			return BOProductListPriceHistory;
		}

		public virtual ApiProductListPriceHistoryResponseModel MapBOToModel(
			BOProductListPriceHistory BOProductListPriceHistory)
		{
			if (BOProductListPriceHistory == null)
			{
				return null;
			}

			var model = new ApiProductListPriceHistoryResponseModel();

			model.SetProperties(BOProductListPriceHistory.EndDate, BOProductListPriceHistory.ListPrice, BOProductListPriceHistory.ModifiedDate, BOProductListPriceHistory.ProductID, BOProductListPriceHistory.StartDate);

			return model;
		}

		public virtual List<ApiProductListPriceHistoryResponseModel> MapBOToModel(
			List<BOProductListPriceHistory> BOs)
		{
			List<ApiProductListPriceHistoryResponseModel> response = new List<ApiProductListPriceHistoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3c6c7a721757eeff84a28e2a29985618</Hash>
</Codenesium>*/