using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiJobCandidateModelMapper
	{
		public virtual ApiJobCandidateClientResponseModel MapClientRequestToResponse(
			int jobCandidateID,
			ApiJobCandidateClientRequestModel request)
		{
			var response = new ApiJobCandidateClientResponseModel();
			response.SetProperties(jobCandidateID,
			                       request.BusinessEntityID,
			                       request.ModifiedDate,
			                       request.Resume);
			return response;
		}

		public virtual ApiJobCandidateClientRequestModel MapClientResponseToRequest(
			ApiJobCandidateClientResponseModel response)
		{
			var request = new ApiJobCandidateClientRequestModel();
			request.SetProperties(
				response.BusinessEntityID,
				response.ModifiedDate,
				response.Resume);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>e66e7386353afb012fb0399c7c099ac3</Hash>
</Codenesium>*/