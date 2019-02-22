using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiPersonServerModelMapper
	{
		public virtual ApiPersonServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPersonServerRequestModel request)
		{
			var response = new ApiPersonServerResponseModel();
			response.SetProperties(id,
			                       request.FirstName,
			                       request.LastName,
			                       request.Phone,
			                       request.Ssn);
			return response;
		}

		public virtual ApiPersonServerRequestModel MapServerResponseToRequest(
			ApiPersonServerResponseModel response)
		{
			var request = new ApiPersonServerRequestModel();
			request.SetProperties(
				response.FirstName,
				response.LastName,
				response.Phone,
				response.Ssn);
			return request;
		}

		public virtual ApiPersonClientRequestModel MapServerResponseToClientRequest(
			ApiPersonServerResponseModel response)
		{
			var request = new ApiPersonClientRequestModel();
			request.SetProperties(
				response.FirstName,
				response.LastName,
				response.Phone,
				response.Ssn);
			return request;
		}

		public JsonPatchDocument<ApiPersonServerRequestModel> CreatePatch(ApiPersonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPersonServerRequestModel>();
			patch.Replace(x => x.FirstName, model.FirstName);
			patch.Replace(x => x.LastName, model.LastName);
			patch.Replace(x => x.Phone, model.Phone);
			patch.Replace(x => x.Ssn, model.Ssn);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>796432a96a39cf0ad4c60734a5db8d69</Hash>
</Codenesium>*/