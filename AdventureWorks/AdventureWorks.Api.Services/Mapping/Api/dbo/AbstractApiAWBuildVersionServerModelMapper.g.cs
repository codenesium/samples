using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiAWBuildVersionServerModelMapper
	{
		public virtual ApiAWBuildVersionServerResponseModel MapServerRequestToResponse(
			int systemInformationID,
			ApiAWBuildVersionServerRequestModel request)
		{
			var response = new ApiAWBuildVersionServerResponseModel();
			response.SetProperties(systemInformationID,
			                       request.Database_Version,
			                       request.ModifiedDate,
			                       request.VersionDate);
			return response;
		}

		public virtual ApiAWBuildVersionServerRequestModel MapServerResponseToRequest(
			ApiAWBuildVersionServerResponseModel response)
		{
			var request = new ApiAWBuildVersionServerRequestModel();
			request.SetProperties(
				response.Database_Version,
				response.ModifiedDate,
				response.VersionDate);
			return request;
		}

		public virtual ApiAWBuildVersionClientRequestModel MapServerResponseToClientRequest(
			ApiAWBuildVersionServerResponseModel response)
		{
			var request = new ApiAWBuildVersionClientRequestModel();
			request.SetProperties(
				response.Database_Version,
				response.ModifiedDate,
				response.VersionDate);
			return request;
		}

		public JsonPatchDocument<ApiAWBuildVersionServerRequestModel> CreatePatch(ApiAWBuildVersionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiAWBuildVersionServerRequestModel>();
			patch.Replace(x => x.Database_Version, model.Database_Version);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.VersionDate, model.VersionDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5eebe0591313b5062d7af1cc790d23d5</Hash>
</Codenesium>*/