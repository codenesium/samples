using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiLocationServerModelMapper
	{
		public virtual ApiLocationServerResponseModel MapServerRequestToResponse(
			short locationID,
			ApiLocationServerRequestModel request)
		{
			var response = new ApiLocationServerResponseModel();
			response.SetProperties(locationID,
			                       request.Availability,
			                       request.CostRate,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiLocationServerRequestModel MapServerResponseToRequest(
			ApiLocationServerResponseModel response)
		{
			var request = new ApiLocationServerRequestModel();
			request.SetProperties(
				response.Availability,
				response.CostRate,
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public virtual ApiLocationClientRequestModel MapServerResponseToClientRequest(
			ApiLocationServerResponseModel response)
		{
			var request = new ApiLocationClientRequestModel();
			request.SetProperties(
				response.Availability,
				response.CostRate,
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiLocationServerRequestModel> CreatePatch(ApiLocationServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLocationServerRequestModel>();
			patch.Replace(x => x.Availability, model.Availability);
			patch.Replace(x => x.CostRate, model.CostRate);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f7703f267ce7ebdec887a54d5d7342c1</Hash>
</Codenesium>*/