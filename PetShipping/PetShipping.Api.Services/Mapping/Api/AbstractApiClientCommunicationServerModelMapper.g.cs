using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiClientCommunicationServerModelMapper
	{
		public virtual ApiClientCommunicationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiClientCommunicationServerRequestModel request)
		{
			var response = new ApiClientCommunicationServerResponseModel();
			response.SetProperties(id,
			                       request.ClientId,
			                       request.DateCreated,
			                       request.EmployeeId,
			                       request.Note);
			return response;
		}

		public virtual ApiClientCommunicationServerRequestModel MapServerResponseToRequest(
			ApiClientCommunicationServerResponseModel response)
		{
			var request = new ApiClientCommunicationServerRequestModel();
			request.SetProperties(
				response.ClientId,
				response.DateCreated,
				response.EmployeeId,
				response.Note);
			return request;
		}

		public virtual ApiClientCommunicationClientRequestModel MapServerResponseToClientRequest(
			ApiClientCommunicationServerResponseModel response)
		{
			var request = new ApiClientCommunicationClientRequestModel();
			request.SetProperties(
				response.ClientId,
				response.DateCreated,
				response.EmployeeId,
				response.Note);
			return request;
		}

		public JsonPatchDocument<ApiClientCommunicationServerRequestModel> CreatePatch(ApiClientCommunicationServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiClientCommunicationServerRequestModel>();
			patch.Replace(x => x.ClientId, model.ClientId);
			patch.Replace(x => x.DateCreated, model.DateCreated);
			patch.Replace(x => x.EmployeeId, model.EmployeeId);
			patch.Replace(x => x.Note, model.Note);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0e87a1179c86aa3e460421b2519d179e</Hash>
</Codenesium>*/