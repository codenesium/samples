using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiSalesPersonModelMapper
	{
		public virtual ApiSalesPersonClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiSalesPersonClientRequestModel request)
		{
			var response = new ApiSalesPersonClientResponseModel();
			response.SetProperties(businessEntityID,
			                       request.Bonus,
			                       request.CommissionPct,
			                       request.ModifiedDate,
			                       request.Rowguid,
			                       request.SalesLastYear,
			                       request.SalesQuota,
			                       request.SalesYTD,
			                       request.TerritoryID);
			return response;
		}

		public virtual ApiSalesPersonClientRequestModel MapClientResponseToRequest(
			ApiSalesPersonClientResponseModel response)
		{
			var request = new ApiSalesPersonClientRequestModel();
			request.SetProperties(
				response.Bonus,
				response.CommissionPct,
				response.ModifiedDate,
				response.Rowguid,
				response.SalesLastYear,
				response.SalesQuota,
				response.SalesYTD,
				response.TerritoryID);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d6cdaa38795adc4ac579964ad7681f6e</Hash>
</Codenesium>*/