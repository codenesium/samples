using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiVersionInfoModelMapper
	{
		public virtual ApiVersionInfoClientResponseModel MapClientRequestToResponse(
			long version,
			ApiVersionInfoClientRequestModel request)
		{
			var response = new ApiVersionInfoClientResponseModel();
			response.SetProperties(version,
			                       request.AppliedOn,
			                       request.Description);
			return response;
		}

		public virtual ApiVersionInfoClientRequestModel MapClientResponseToRequest(
			ApiVersionInfoClientResponseModel response)
		{
			var request = new ApiVersionInfoClientRequestModel();
			request.SetProperties(
				response.AppliedOn,
				response.Description);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>b2dbeb9d2008e8e1aad9e3a482b9071c</Hash>
</Codenesium>*/