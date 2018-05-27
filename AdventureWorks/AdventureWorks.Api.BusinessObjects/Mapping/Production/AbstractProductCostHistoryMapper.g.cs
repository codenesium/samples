using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductCostHistoryMapper
	{
		public virtual DTOProductCostHistory MapModelToDTO(
			int productID,
			ApiProductCostHistoryRequestModel model
			)
		{
			DTOProductCostHistory dtoProductCostHistory = new DTOProductCostHistory();

			dtoProductCostHistory.SetProperties(
				productID,
				model.EndDate,
				model.ModifiedDate,
				model.StandardCost,
				model.StartDate);
			return dtoProductCostHistory;
		}

		public virtual ApiProductCostHistoryResponseModel MapDTOToModel(
			DTOProductCostHistory dtoProductCostHistory)
		{
			if (dtoProductCostHistory == null)
			{
				return null;
			}

			var model = new ApiProductCostHistoryResponseModel();

			model.SetProperties(dtoProductCostHistory.EndDate, dtoProductCostHistory.ModifiedDate, dtoProductCostHistory.ProductID, dtoProductCostHistory.StandardCost, dtoProductCostHistory.StartDate);

			return model;
		}

		public virtual List<ApiProductCostHistoryResponseModel> MapDTOToModel(
			List<DTOProductCostHistory> dtos)
		{
			List<ApiProductCostHistoryResponseModel> response = new List<ApiProductCostHistoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>55bc42fe814df723e7316b738f1d1fc6</Hash>
</Codenesium>*/