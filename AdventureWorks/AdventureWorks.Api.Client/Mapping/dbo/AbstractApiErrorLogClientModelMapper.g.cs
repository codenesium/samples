using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiErrorLogModelMapper
	{
		public virtual ApiErrorLogClientResponseModel MapClientRequestToResponse(
			int errorLogID,
			ApiErrorLogClientRequestModel request)
		{
			var response = new ApiErrorLogClientResponseModel();
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

		public virtual ApiErrorLogClientRequestModel MapClientResponseToRequest(
			ApiErrorLogClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>65dad1a30035e84a8b84ad978d30159b</Hash>
</Codenesium>*/