using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public abstract class AbstractApiPostTypesModelMapper
	{
		public virtual ApiPostTypesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostTypesClientRequestModel request)
		{
			var response = new ApiPostTypesClientResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiPostTypesClientRequestModel MapClientResponseToRequest(
			ApiPostTypesClientResponseModel response)
		{
			var request = new ApiPostTypesClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>e1b3b4292952fe01883c4c73ad9c1837</Hash>
</Codenesium>*/