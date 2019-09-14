using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiEmployeeServerModelMapper : IApiEmployeeServerModelMapper
	{
		public virtual ApiEmployeeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEmployeeServerRequestModel request)
		{
			var response = new ApiEmployeeServerResponseModel();
			response.SetProperties(id,
			                       request.FirstName,
			                       request.IsSalesPerson,
			                       request.IsShipper,
			                       request.LastName);
			return response;
		}

		public virtual ApiEmployeeServerRequestModel MapServerResponseToRequest(
			ApiEmployeeServerResponseModel response)
		{
			var request = new ApiEmployeeServerRequestModel();
			request.SetProperties(
				response.FirstName,
				response.IsSalesPerson,
				response.IsShipper,
				response.LastName);
			return request;
		}

		public virtual ApiEmployeeClientRequestModel MapServerResponseToClientRequest(
			ApiEmployeeServerResponseModel response)
		{
			var request = new ApiEmployeeClientRequestModel();
			request.SetProperties(
				response.FirstName,
				response.IsSalesPerson,
				response.IsShipper,
				response.LastName);
			return request;
		}

		public JsonPatchDocument<ApiEmployeeServerRequestModel> CreatePatch(ApiEmployeeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEmployeeServerRequestModel>();
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.IsSalesPerson, model.IsSalesPerson);
			patch.Replace(x => x.IsShipper, model.IsShipper);
			patch.Replace(x => x.LastName, model.LastName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e15d6080459fd9d686838166b0ebaf31</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/