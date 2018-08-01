using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiSalesPersonQuotaHistoryModelMapper
	{
		public virtual ApiSalesPersonQuotaHistoryResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryRequestModel request)
		{
			var response = new ApiSalesPersonQuotaHistoryResponseModel();
			response.SetProperties(businessEntityID,
			                       request.ModifiedDate,
			                       request.QuotaDate,
			                       request.Rowguid,
			                       request.SalesQuota);
			return response;
		}

		public virtual ApiSalesPersonQuotaHistoryRequestModel MapResponseToRequest(
			ApiSalesPersonQuotaHistoryResponseModel response)
		{
			var request = new ApiSalesPersonQuotaHistoryRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.QuotaDate,
				response.Rowguid,
				response.SalesQuota);
			return request;
		}

		public JsonPatchDocument<ApiSalesPersonQuotaHistoryRequestModel> CreatePatch(ApiSalesPersonQuotaHistoryRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSalesPersonQuotaHistoryRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.QuotaDate, model.QuotaDate);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.SalesQuota, model.SalesQuota);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>6e26d5a5c0dd1ecaf8d2944685917249</Hash>
</Codenesium>*/