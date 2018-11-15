using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesReasonServerModelMapper
	{
		public virtual ApiSalesReasonServerResponseModel MapServerRequestToResponse(
			int salesReasonID,
			ApiSalesReasonServerRequestModel request)
		{
			var response = new ApiSalesReasonServerResponseModel();
			response.SetProperties(salesReasonID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.ReasonType);
			return response;
		}

		public virtual ApiSalesReasonServerRequestModel MapServerResponseToRequest(
			ApiSalesReasonServerResponseModel response)
		{
			var request = new ApiSalesReasonServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.ReasonType);
			return request;
		}

		public virtual ApiSalesReasonClientRequestModel MapServerResponseToClientRequest(
			ApiSalesReasonServerResponseModel response)
		{
			var request = new ApiSalesReasonClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.ReasonType);
			return request;
		}

		public JsonPatchDocument<ApiSalesReasonServerRequestModel> CreatePatch(ApiSalesReasonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSalesReasonServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ReasonType, model.ReasonType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>be67ec75cc6584eab519907f383b5a90</Hash>
</Codenesium>*/