using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public abstract class AbstractApiStudioModelMapper
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
    <Hash>12eea0d68e96d3e2e04cff6c0aae503d</Hash>
</Codenesium>*/