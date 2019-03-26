using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiJobCandidateServerModelMapper
	{
		public virtual ApiJobCandidateServerResponseModel MapServerRequestToResponse(
			int jobCandidateID,
			ApiJobCandidateServerRequestModel request)
		{
			var response = new ApiJobCandidateServerResponseModel();
			response.SetProperties(jobCandidateID,
			                       request.BusinessEntityID,
			                       request.ModifiedDate,
			                       request.Resume);
			return response;
		}

		public virtual ApiJobCandidateServerRequestModel MapServerResponseToRequest(
			ApiJobCandidateServerResponseModel response)
		{
			var request = new ApiJobCandidateServerRequestModel();
			request.SetProperties(
				response.BusinessEntityID,
				response.ModifiedDate,
				response.Resume);
			return request;
		}

		public virtual ApiJobCandidateClientRequestModel MapServerResponseToClientRequest(
			ApiJobCandidateServerResponseModel response)
		{
			var request = new ApiJobCandidateClientRequestModel();
			request.SetProperties(
				response.BusinessEntityID,
				response.ModifiedDate,
				response.Resume);
			return request;
		}

		public JsonPatchDocument<ApiJobCandidateServerRequestModel> CreatePatch(ApiJobCandidateServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiJobCandidateServerRequestModel>();
			patch.Replace(x => x.BusinessEntityID, model.BusinessEntityID);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Resume, model.Resume);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8d1987a9adddbac111c065fcd28253db</Hash>
</Codenesium>*/