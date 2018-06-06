using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductCostHistoryMapper
	{
		public virtual BOProductCostHistory MapModelToBO(
			int productID,
			ApiProductCostHistoryRequestModel model
			)
		{
			BOProductCostHistory boProductCostHistory = new BOProductCostHistory();

			boProductCostHistory.SetProperties(
				productID,
				model.EndDate,
				model.ModifiedDate,
				model.StandardCost,
				model.StartDate);
			return boProductCostHistory;
		}

		public virtual ApiProductCostHistoryResponseModel MapBOToModel(
			BOProductCostHistory boProductCostHistory)
		{
			var model = new ApiProductCostHistoryResponseModel();

			model.SetProperties(boProductCostHistory.EndDate, boProductCostHistory.ModifiedDate, boProductCostHistory.ProductID, boProductCostHistory.StandardCost, boProductCostHistory.StartDate);

			return model;
		}

		public virtual List<ApiProductCostHistoryResponseModel> MapBOToModel(
			List<BOProductCostHistory> items)
		{
			List<ApiProductCostHistoryResponseModel> response = new List<ApiProductCostHistoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2e59d48afacb2314864118235c746d65</Hash>
</Codenesium>*/