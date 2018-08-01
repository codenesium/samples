using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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

			model.SetProperties(boProductCostHistory.ProductID, boProductCostHistory.EndDate, boProductCostHistory.ModifiedDate, boProductCostHistory.StandardCost, boProductCostHistory.StartDate);

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
    <Hash>1886aa1e79030a5f2f42fc1c25214a0a</Hash>
</Codenesium>*/