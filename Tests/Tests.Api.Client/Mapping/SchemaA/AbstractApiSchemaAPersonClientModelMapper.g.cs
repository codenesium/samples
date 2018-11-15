using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiSchemaAPersonModelMapper
	{
		public virtual ApiSchemaAPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSchemaAPersonClientRequestModel request)
		{
			var response = new ApiSchemaAPersonClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiSchemaAPersonClientRequestModel MapClientResponseToRequest(
			ApiSchemaAPersonClientResponseModel response)
		{
			var request = new ApiSchemaAPersonClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d82231296df8eb7816480c7d7c27d609</Hash>
</Codenesium>*/