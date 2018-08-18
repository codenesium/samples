using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractEmployeePayHistoryMapper
	{
		public virtual BOEmployeePayHistory MapModelToBO(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel model
			)
		{
			BOEmployeePayHistory boEmployeePayHistory = new BOEmployeePayHistory();
			boEmployeePayHistory.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PayFrequency,
				model.Rate,
				model.RateChangeDate);
			return boEmployeePayHistory;
		}

		public virtual ApiEmployeePayHistoryResponseModel MapBOToModel(
			BOEmployeePayHistory boEmployeePayHistory)
		{
			var model = new ApiEmployeePayHistoryResponseModel();

			model.SetProperties(boEmployeePayHistory.BusinessEntityID, boEmployeePayHistory.ModifiedDate, boEmployeePayHistory.PayFrequency, boEmployeePayHistory.Rate, boEmployeePayHistory.RateChangeDate);

			return model;
		}

		public virtual List<ApiEmployeePayHistoryResponseModel> MapBOToModel(
			List<BOEmployeePayHistory> items)
		{
			List<ApiEmployeePayHistoryResponseModel> response = new List<ApiEmployeePayHistoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8019d27127039c35f3f4a0dcdfffafa2</Hash>
</Codenesium>*/