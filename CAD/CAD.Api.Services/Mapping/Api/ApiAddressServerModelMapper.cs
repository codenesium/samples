using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiAddressServerModelMapper : IApiAddressServerModelMapper
	{
		public virtual ApiAddressServerResponseModel MapServerRequestToResponse(
			int id,
			ApiAddressServerRequestModel request)
		{
			var response = new ApiAddressServerResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.City,
			                       request.State,
			                       request.Zip);
			return response;
		}

		public virtual ApiAddressServerRequestModel MapServerResponseToRequest(
			ApiAddressServerResponseModel response)
		{
			var request = new ApiAddressServerRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.City,
				response.State,
				response.Zip);
			return request;
		}

		public virtual ApiAddressClientRequestModel MapServerResponseToClientRequest(
			ApiAddressServerResponseModel response)
		{
			var request = new ApiAddressClientRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.City,
				response.State,
				response.Zip);
			return request;
		}

		public JsonPatchDocument<ApiAddressServerRequestModel> CreatePatch(ApiAddressServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAddressServerRequestModel>();
			patch.Replace(x => x.Address1, model.Address1);
			patch.Replace(x => x.Address2, model.Address2);
			patch.Replace(x => x.City, model.City);
			patch.Replace(x => x.State, model.State);
			patch.Replace(x => x.Zip, model.Zip);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>847a7ca1e1ce5ee3a1d5bebadf2b125c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/