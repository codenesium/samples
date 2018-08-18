using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiClientCommunicationModelMapper
	{
		public virtual ApiClientCommunicationResponseModel MapRequestToResponse(
			int id,
			ApiClientCommunicationRequestModel request)
		{
			var response = new ApiClientCommunicationResponseModel();
			response.SetProperties(id,
			                       request.ClientId,
			                       request.DateCreated,
			                       request.EmployeeId,
			                       request.Notes);
			return response;
		}

		public virtual ApiClientCommunicationRequestModel MapResponseToRequest(
			ApiClientCommunicationResponseModel response)
		{
			var request = new ApiClientCommunicationRequestModel();
			request.SetProperties(
				response.ClientId,
				response.DateCreated,
				response.EmployeeId,
				response.Notes);
			return request;
		}

		public JsonPatchDocument<ApiClientCommunicationRequestModel> CreatePatch(ApiClientCommunicationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiClientCommunicationRequestModel>();
			patch.Replace(x => x.ClientId, model.ClientId);
			patch.Replace(x => x.DateCreated, model.DateCreated);
			patch.Replace(x => x.EmployeeId, model.EmployeeId);
			patch.Replace(x => x.Notes, model.Notes);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0f61f4fb9d6b539f17ede17e2cd69085</Hash>
</Codenesium>*/