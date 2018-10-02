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
			                       request.Note);
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
				response.Note);
			return request;
		}

		public JsonPatchDocument<ApiClientCommunicationRequestModel> CreatePatch(ApiClientCommunicationRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiClientCommunicationRequestModel>();
			patch.Replace(x => x.ClientId, model.ClientId);
			patch.Replace(x => x.DateCreated, model.DateCreated);
			patch.Replace(x => x.EmployeeId, model.EmployeeId);
			patch.Replace(x => x.Note, model.Note);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d80c57fa54b777b6f7684ccd697e0586</Hash>
</Codenesium>*/