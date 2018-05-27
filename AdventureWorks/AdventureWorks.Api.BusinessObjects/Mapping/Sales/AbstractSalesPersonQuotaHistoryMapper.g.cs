using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSalesPersonQuotaHistoryMapper
	{
		public virtual DTOSalesPersonQuotaHistory MapModelToDTO(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel model
			)
		{
			DTOSalesPersonQuotaHistory dtoSalesPersonQuotaHistory = new DTOSalesPersonQuotaHistory();

			dtoSalesPersonQuotaHistory.SetProperties(
				businessEntityID,
				model.ModifiedDate,
				model.QuotaDate,
				model.Rowguid,
				model.SalesQuota);
			return dtoSalesPersonQuotaHistory;
		}

		public virtual ApiSalesPersonQuotaHistoryResponseModel MapDTOToModel(
			DTOSalesPersonQuotaHistory dtoSalesPersonQuotaHistory)
		{
			if (dtoSalesPersonQuotaHistory == null)
			{
				return null;
			}

			var model = new ApiSalesPersonQuotaHistoryResponseModel();

			model.SetProperties(dtoSalesPersonQuotaHistory.BusinessEntityID, dtoSalesPersonQuotaHistory.ModifiedDate, dtoSalesPersonQuotaHistory.QuotaDate, dtoSalesPersonQuotaHistory.Rowguid, dtoSalesPersonQuotaHistory.SalesQuota);

			return model;
		}

		public virtual List<ApiSalesPersonQuotaHistoryResponseModel> MapDTOToModel(
			List<DTOSalesPersonQuotaHistory> dtos)
		{
			List<ApiSalesPersonQuotaHistoryResponseModel> response = new List<ApiSalesPersonQuotaHistoryResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d1aa87ca9067eb14310a2a995b23a2ea</Hash>
</Codenesium>*/