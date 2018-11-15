using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractApiEmployeeServerModelMapper
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
    <Hash>86f111c6a008dd75f241c990cce2caef</Hash>
</Codenesium>*/