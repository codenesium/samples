using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallServerModelMapper : IApiCallServerModelMapper
	{
		public virtual ApiCallServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallServerRequestModel request)
		{
			var response = new ApiCallServerResponseModel();
			response.SetProperties(id,
			                       request.AddressId,
			                       request.CallDispositionId,
			                       request.CallStatusId,
			                       request.CallString,
			                       request.CallTypeId,
			                       request.DateCleared,
			                       request.DateCreated,
			                       request.DateDispatched,
			                       request.QuickCallNumber);
			return response;
		}

		public virtual ApiCallServerRequestModel MapServerResponseToRequest(
			ApiCallServerResponseModel response)
		{
			var request = new ApiCallServerRequestModel();
			request.SetProperties(
				response.AddressId,
				response.CallDispositionId,
				response.CallStatusId,
				response.CallString,
				response.CallTypeId,
				response.DateCleared,
				response.DateCreated,
				response.DateDispatched,
				response.QuickCallNumber);
			return request;
		}

		public virtual ApiCallClientRequestModel MapServerResponseToClientRequest(
			ApiCallServerResponseModel response)
		{
			var request = new ApiCallClientRequestModel();
			request.SetProperties(
				response.AddressId,
				response.CallDispositionId,
				response.CallStatusId,
				response.CallString,
				response.CallTypeId,
				response.DateCleared,
				response.DateCreated,
				response.DateDispatched,
				response.QuickCallNumber);
			return request;
		}

		public JsonPatchDocument<ApiCallServerRequestModel> CreatePatch(ApiCallServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCallServerRequestModel>();
			patch.Replace(x => x.AddressId, model.AddressId);
			patch.Replace(x => x.CallDispositionId, model.CallDispositionId);
			patch.Replace(x => x.CallStatusId, model.CallStatusId);
			patch.Replace(x => x.CallString, model.CallString);
			patch.Replace(x => x.CallTypeId, model.CallTypeId);
			patch.Replace(x => x.DateCleared, model.DateCleared);
			patch.Replace(x => x.DateCreated, model.DateCreated);
			patch.Replace(x => x.DateDispatched, model.DateDispatched);
			patch.Replace(x => x.QuickCallNumber, model.QuickCallNumber);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>80c0fb70d4104b266d40417c929c9ea8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/