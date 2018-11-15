using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiErrorLogServerModelMapper
	{
		public virtual ApiErrorLogServerResponseModel MapServerRequestToResponse(
			int errorLogID,
			ApiErrorLogServerRequestModel request)
		{
			var response = new ApiErrorLogServerResponseModel();
			response.SetProperties(errorLogID,
			                       request.ErrorLine,
			                       request.ErrorMessage,
			                       request.ErrorNumber,
			                       request.ErrorProcedure,
			                       request.ErrorSeverity,
			                       request.ErrorState,
			                       request.ErrorTime,
			                       request.UserName);
			return response;
		}

		public virtual ApiErrorLogServerRequestModel MapServerResponseToRequest(
			ApiErrorLogServerResponseModel response)
		{
			var request = new ApiErrorLogServerRequestModel();
			request.SetProperties(
				response.ErrorLine,
				response.ErrorMessage,
				response.ErrorNumber,
				response.ErrorProcedure,
				response.ErrorSeverity,
				response.ErrorState,
				response.ErrorTime,
				response.UserName);
			return request;
		}

		public virtual ApiErrorLogClientRequestModel MapServerResponseToClientRequest(
			ApiErrorLogServerResponseModel response)
		{
			var request = new ApiErrorLogClientRequestModel();
			request.SetProperties(
				response.ErrorLine,
				response.ErrorMessage,
				response.ErrorNumber,
				response.ErrorProcedure,
				response.ErrorSeverity,
				response.ErrorState,
				response.ErrorTime,
				response.UserName);
			return request;
		}

		public JsonPatchDocument<ApiErrorLogServerRequestModel> CreatePatch(ApiErrorLogServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiErrorLogServerRequestModel>();
			patch.Replace(x => x.ErrorLine, model.ErrorLine);
			patch.Replace(x => x.ErrorMessage, model.ErrorMessage);
			patch.Replace(x => x.ErrorNumber, model.ErrorNumber);
			patch.Replace(x => x.ErrorProcedure, model.ErrorProcedure);
			patch.Replace(x => x.ErrorSeverity, model.ErrorSeverity);
			patch.Replace(x => x.ErrorState, model.ErrorState);
			patch.Replace(x => x.ErrorTime, model.ErrorTime);
			patch.Replace(x => x.UserName, model.UserName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>2c4f7950c31740f7fac3b120f6957adc</Hash>
</Codenesium>*/