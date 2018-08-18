using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiUserModelMapper
	{
		public virtual ApiUserResponseModel MapRequestToResponse(
			string id,
			ApiUserRequestModel request)
		{
			var response = new ApiUserResponseModel();
			response.SetProperties(id,
			                       request.DisplayName,
			                       request.EmailAddress,
			                       request.ExternalId,
			                       request.ExternalIdentifiers,
			                       request.IdentificationToken,
			                       request.IsActive,
			                       request.IsService,
			                       request.JSON,
			                       request.Username);
			return response;
		}

		public virtual ApiUserRequestModel MapResponseToRequest(
			ApiUserResponseModel response)
		{
			var request = new ApiUserRequestModel();
			request.SetProperties(
				response.DisplayName,
				response.EmailAddress,
				response.ExternalId,
				response.ExternalIdentifiers,
				response.IdentificationToken,
				response.IsActive,
				response.IsService,
				response.JSON,
				response.Username);
			return request;
		}

		public JsonPatchDocument<ApiUserRequestModel> CreatePatch(ApiUserRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserRequestModel>();
			patch.Replace(x => x.DisplayName, model.DisplayName);
			patch.Replace(x => x.EmailAddress, model.EmailAddress);
			patch.Replace(x => x.ExternalId, model.ExternalId);
			patch.Replace(x => x.ExternalIdentifiers, model.ExternalIdentifiers);
			patch.Replace(x => x.IdentificationToken, model.IdentificationToken);
			patch.Replace(x => x.IsActive, model.IsActive);
			patch.Replace(x => x.IsService, model.IsService);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Username, model.Username);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b546fdf047b248a24948be9ae4e9b15e</Hash>
</Codenesium>*/