using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractEmployeePayHistoryMapper
	{
		public virtual BOEmployeePayHistory MapModelToBO(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel model
			)
		{
			BOEmployeePayHistory BOEmployeePayHistory = new BOEmployeePayHistory();

			BOEmployeePayHistory.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.PayFrequency,
				model.Rate,
				model.RateChangeDate);
			return BOEmployeePayHistory;
		}

		public virtual ApiEmployeePayHistoryResponseModel MapBOToModel(
			BOEmployeePayHistory BOEmployeePayHistory)
		{
			if (BOEmployeePayHistory == null)
			{
				return null;
			}

			var model = new ApiEmployeePayHistoryResponseModel();

			model.SetProperties(BOEmployeePayHistory.BusinessEntityID, BOEmployeePayHistory.ModifiedDate, BOEmployeePayHistory.PayFrequency, BOEmployeePayHistory.Rate, BOEmployeePayHistory.RateChangeDate);

			return model;
		}

		public virtual List<ApiEmployeePayHistoryResponseModel> MapBOToModel(
			List<BOEmployeePayHistory> BOs)
		{
			List<ApiEmployeePayHistoryResponseModel> response = new List<ApiEmployeePayHistoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e8e6cf83c97f93acc8410e1b551d80f6</Hash>
</Codenesium>*/