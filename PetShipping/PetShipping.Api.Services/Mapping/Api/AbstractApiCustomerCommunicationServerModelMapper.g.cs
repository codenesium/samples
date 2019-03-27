using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiCustomerCommunicationServerModelMapper
	{
		public virtual ApiCustomerCommunicationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCustomerCommunicationServerRequestModel request)
		{
			var response = new ApiCustomerCommunicationServerResponseModel();
			response.SetProperties(id,
			                       request.CustomerId,
			                       request.DateCreated,
			                       request.EmployeeId,
			                       request.Notes);
			return response;
		}

		public virtual ApiCustomerCommunicationServerRequestModel MapServerResponseToRequest(
			ApiCustomerCommunicationServerResponseModel response)
		{
			var request = new ApiCustomerCommunicationServerRequestModel();
			request.SetProperties(
				response.CustomerId,
				response.DateCreated,
				response.EmployeeId,
				response.Notes);
			return request;
		}

		public virtual ApiCustomerCommunicationClientRequestModel MapServerResponseToClientRequest(
			ApiCustomerCommunicationServerResponseModel response)
		{
			var request = new ApiCustomerCommunicationClientRequestModel();
			request.SetProperties(
				response.CustomerId,
				response.DateCreated,
				response.EmployeeId,
				response.Notes);
			return request;
		}

		public JsonPatchDocument<ApiCustomerCommunicationServerRequestModel> CreatePatch(ApiCustomerCommunicationServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCustomerCommunicationServerRequestModel>();
			patch.Replace(x => x.CustomerId, model.CustomerId);
			patch.Replace(x => x.DateCreated, model.DateCreated);
			patch.Replace(x => x.EmployeeId, model.EmployeeId);
			patch.Replace(x => x.Notes, model.Notes);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a3e25e448fdcc3259ec15659d99435d2</Hash>
</Codenesium>*/