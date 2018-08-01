using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiAWBuildVersionModelMapper
	{
		public virtual ApiAWBuildVersionResponseModel MapRequestToResponse(
			int systemInformationID,
			ApiAWBuildVersionRequestModel request)
		{
			var response = new ApiAWBuildVersionResponseModel();
			response.SetProperties(systemInformationID,
			                       request.Database_Version,
			                       request.ModifiedDate,
			                       request.VersionDate);
			return response;
		}

		public virtual ApiAWBuildVersionRequestModel MapResponseToRequest(
			ApiAWBuildVersionResponseModel response)
		{
			var request = new ApiAWBuildVersionRequestModel();
			request.SetProperties(
				response.Database_Version,
				response.ModifiedDate,
				response.VersionDate);
			return request;
		}

		public JsonPatchDocument<ApiAWBuildVersionRequestModel> CreatePatch(ApiAWBuildVersionRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAWBuildVersionRequestModel>();
			patch.Replace(x => x.Database_Version, model.Database_Version);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.VersionDate, model.VersionDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9fabae30a701a7802a1737275659149d</Hash>
</Codenesium>*/