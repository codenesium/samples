using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiSchemaBPersonModelMapper
	{
		public virtual ApiSchemaBPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSchemaBPersonClientRequestModel request)
		{
			var response = new ApiSchemaBPersonClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSchemaBPersonClientRequestModel MapClientResponseToRequest(
			ApiSchemaBPersonClientResponseModel response)
		{
			var request = new ApiSchemaBPersonClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>5a2e06bfd0db988a2e4b2cb0e46a5eac</Hash>
</Codenesium>*/