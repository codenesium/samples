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
			BOProductCostHistory BOProductCostHistory = new BOProductCostHistory();

			BOProductCostHistory.SetProperties(
				productID,
				model.EndDate,
				model.ModifiedDate,
				model.StandardCost,
				model.StartDate);
			return BOProductCostHistory;
		}

		public virtual ApiProductCostHistoryResponseModel MapBOToModel(
			BOProductCostHistory BOProductCostHistory)
		{
			if (BOProductCostHistory == null)
			{
				return null;
			}

			var model = new ApiProductCostHistoryResponseModel();

			model.SetProperties(BOProductCostHistory.EndDate, BOProductCostHistory.ModifiedDate, BOProductCostHistory.ProductID, BOProductCostHistory.StandardCost, BOProductCostHistory.StartDate);

			return model;
		}

		public virtual List<ApiProductCostHistoryResponseModel> MapBOToModel(
			List<BOProductCostHistory> BOs)
		{
			List<ApiProductCostHistoryResponseModel> response = new List<ApiProductCostHistoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>84457234bd26c2e452a87994346ec172</Hash>
</Codenesium>*/