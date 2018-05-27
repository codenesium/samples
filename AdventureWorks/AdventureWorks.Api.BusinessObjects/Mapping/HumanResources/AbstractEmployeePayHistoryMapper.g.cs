using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLEmployeePayHistoryMapper
	{
		public virtual DTOEmployeePayHistory MapModelToDTO(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel model
			)
		{
			DTOEmployeePayHistory dtoEmployeePayHistory = new DTOEmployeePayHistory();

			dtoEmployeePayHistory.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PayFrequency,
				model.Rate,
				model.RateChangeDate);
			return dtoEmployeePayHistory;
		}

		public virtual ApiEmployeePayHistoryResponseModel MapDTOToModel(
			DTOEmployeePayHistory dtoEmployeePayHistory)
		{
			if (dtoEmployeePayHistory == null)
			{
				return null;
			}

			var model = new ApiEmployeePayHistoryResponseModel();

			model.SetProperties(dtoEmployeePayHistory.BusinessEntityID, dtoEmployeePayHistory.ModifiedDate, dtoEmployeePayHistory.PayFrequency, dtoEmployeePayHistory.Rate, dtoEmployeePayHistory.RateChangeDate);

			return model;
		}

		public virtual List<ApiEmployeePayHistoryResponseModel> MapDTOToModel(
			List<DTOEmployeePayHistory> dtos)
		{
			List<ApiEmployeePayHistoryResponseModel> response = new List<ApiEmployeePayHistoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>66b2448e5a6a4e835626304b687e839d</Hash>
</Codenesium>*/