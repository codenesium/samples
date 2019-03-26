using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiAWBuildVersionModelMapper
	{
		public virtual ApiAWBuildVersionClientResponseModel MapClientRequestToResponse(
			int systemInformationID,
			ApiAWBuildVersionClientRequestModel request)
		{
			var response = new ApiAWBuildVersionClientResponseModel();
			response.SetProperties(systemInformationID,
			                       request.Database_Version,
			                       request.ModifiedDate,
			                       request.VersionDate);
			return response;
		}

		public virtual ApiAWBuildVersionClientRequestModel MapClientResponseToRequest(
			ApiAWBuildVersionClientResponseModel response)
		{
			var request = new ApiAWBuildVersionClientRequestModel();
			request.SetProperties(
				response.Database_Version,
				response.ModifiedDate,
				response.VersionDate);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>734497abc157d6feacf49a8de942930f</Hash>
</Codenesium>*/