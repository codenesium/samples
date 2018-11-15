using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiIncludedColumnTestModelMapper
	{
		public virtual ApiIncludedColumnTestClientResponseModel MapClientRequestToResponse(
			int id,
			ApiIncludedColumnTestClientRequestModel request)
		{
			var response = new ApiIncludedColumnTestClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.Name2);
			return response;
		}

		public virtual ApiIncludedColumnTestClientRequestModel MapClientResponseToRequest(
			ApiIncludedColumnTestClientResponseModel response)
		{
			var request = new ApiIncludedColumnTestClientRequestModel();
			request.SetProperties(
				response.Name,
				response.Name2);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d066b091ec31aedd3e61668d18e579fc</Hash>
</Codenesium>*/