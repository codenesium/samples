using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public class ApiEventStatusModelMapper : IApiEventStatusModelMapper
	{
		public virtual ApiEventStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventStatusClientRequestModel request)
		{
			var response = new ApiEventStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiEventStatusClientRequestModel MapClientResponseToRequest(
			ApiEventStatusClientResponseModel response)
		{
			var request = new ApiEventStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>86b05224d4548b288124e4023ca0894e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/