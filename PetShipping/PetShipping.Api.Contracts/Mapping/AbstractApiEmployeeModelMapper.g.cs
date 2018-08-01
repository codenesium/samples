using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public abstract class AbstractApiEmployeeModelMapper
	{
		public virtual ApiEmployeeResponseModel MapRequestToResponse(
			int id,
			ApiEmployeeRequestModel request)
		{
			var response = new ApiEmployeeResponseModel();
			response.SetProperties(id,
			                       request.FirstName,
			                       request.IsSalesPerson,
			                       request.IsShipper,
			                       request.LastName);
			return response;
		}

		public virtual ApiEmployeeRequestModel MapResponseToRequest(
			ApiEmployeeResponseModel response)
		{
			var request = new ApiEmployeeRequestModel();
			request.SetProperties(
				response.FirstName,
				response.IsSalesPerson,
				response.IsShipper,
				response.LastName);
			return request;
		}

		public JsonPatchDocument<ApiEmployeeRequestModel> CreatePatch(ApiEmployeeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEmployeeRequestModel>();
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.IsSalesPerson, model.IsSalesPerson);
			patch.Replace(x => x.IsShipper, model.IsShipper);
			patch.Replace(x => x.LastName, model.LastName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>37b9bb6ec130704c74fa642958281b06</Hash>
</Codenesium>*/