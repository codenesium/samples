using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public class ApiStudioModelMapper : IApiStudioModelMapper
	{
		public virtual ApiStudioClientResponseModel MapClientRequestToResponse(
			int id,
			ApiStudioClientRequestModel request)
		{
			var response = new ApiStudioClientResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.City,
			                       request.Name,
			                       request.Province,
			                       request.Website,
			                       request.Zip);
			return response;
		}

		public virtual ApiStudioClientRequestModel MapClientResponseToRequest(
			ApiStudioClientResponseModel response)
		{
			var request = new ApiStudioClientRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.City,
				response.Name,
				response.Province,
				response.Website,
				response.Zip);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>f2f6b779ddf994073380f8243c50cf9d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/