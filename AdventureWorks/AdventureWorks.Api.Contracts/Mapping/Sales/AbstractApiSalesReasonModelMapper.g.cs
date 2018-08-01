using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiSalesReasonModelMapper
	{
		public virtual ApiSalesReasonResponseModel MapRequestToResponse(
			int salesReasonID,
			ApiSalesReasonRequestModel request)
		{
			var response = new ApiSalesReasonResponseModel();
			response.SetProperties(salesReasonID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.ReasonType);
			return response;
		}

		public virtual ApiSalesReasonRequestModel MapResponseToRequest(
			ApiSalesReasonResponseModel response)
		{
			var request = new ApiSalesReasonRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.ReasonType);
			return request;
		}

		public JsonPatchDocument<ApiSalesReasonRequestModel> CreatePatch(ApiSalesReasonRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSalesReasonRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ReasonType, model.ReasonType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>913eb11d26d5288dfa6ffd5998cc6a76</Hash>
</Codenesium>*/