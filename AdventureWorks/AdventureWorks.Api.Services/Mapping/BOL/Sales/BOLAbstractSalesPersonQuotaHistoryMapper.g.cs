using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesPersonQuotaHistoryMapper
	{
		public virtual BOSalesPersonQuotaHistory MapModelToBO(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel model
			)
		{
			BOSalesPersonQuotaHistory BOSalesPersonQuotaHistory = new BOSalesPersonQuotaHistory();

			BOSalesPersonQuotaHistory.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.QuotaDate,
				model.Rowguid,
				model.SalesQuota);
			return BOSalesPersonQuotaHistory;
		}

		public virtual ApiSalesPersonQuotaHistoryResponseModel MapBOToModel(
			BOSalesPersonQuotaHistory BOSalesPersonQuotaHistory)
		{
			if (BOSalesPersonQuotaHistory == null)
			{
				return null;
			}

			var model = new ApiSalesPersonQuotaHistoryResponseModel();

			model.SetProperties(BOSalesPersonQuotaHistory.BusinessEntityID, BOSalesPersonQuotaHistory.ModifiedDate, BOSalesPersonQuotaHistory.QuotaDate, BOSalesPersonQuotaHistory.Rowguid, BOSalesPersonQuotaHistory.SalesQuota);

			return model;
		}

		public virtual List<ApiSalesPersonQuotaHistoryResponseModel> MapBOToModel(
			List<BOSalesPersonQuotaHistory> BOs)
		{
			List<ApiSalesPersonQuotaHistoryResponseModel> response = new List<ApiSalesPersonQuotaHistoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a12b4d9ad1a743b76a822c9e9dd5f5d2</Hash>
</Codenesium>*/