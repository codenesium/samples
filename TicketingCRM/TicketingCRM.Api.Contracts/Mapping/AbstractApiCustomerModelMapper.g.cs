using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiCustomerModelMapper
	{
		public virtual ApiCustomerResponseModel MapRequestToResponse(
			int id,
			ApiCustomerRequestModel request)
		{
			var response = new ApiCustomerResponseModel();
			response.SetProperties(id,
			                       request.Email,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone);
			return response;
		}

		public virtual ApiCustomerRequestModel MapResponseToRequest(
			ApiCustomerResponseModel response)
		{
			var request = new ApiCustomerRequestModel();
			request.SetProperties(
				response.Email,
				response.FirstName,
				response.LastName,
				response.Phone);
			return request;
		}

		public JsonPatchDocument<ApiCustomerRequestModel> CreatePatch(ApiCustomerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCustomerRequestModel>();
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Phone, model.Phone);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7b38b06aaf8560fe738b4edac17361b5</Hash>
</Codenesium>*/