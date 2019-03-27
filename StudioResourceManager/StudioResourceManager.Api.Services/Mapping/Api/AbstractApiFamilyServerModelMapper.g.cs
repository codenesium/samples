using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiFamilyServerModelMapper
	{
		public virtual ApiFamilyServerResponseModel MapServerRequestToResponse(
			int id,
			ApiFamilyServerRequestModel request)
		{
			var response = new ApiFamilyServerResponseModel();
			response.SetProperties(id,
			                       request.Notes,
			                       request.PrimaryContactEmail,
			                       request.PrimaryContactFirstName,
			                       request.PrimaryContactLastName,
			                       request.PrimaryContactPhone);
			return response;
		}

		public virtual ApiFamilyServerRequestModel MapServerResponseToRequest(
			ApiFamilyServerResponseModel response)
		{
			var request = new ApiFamilyServerRequestModel();
			request.SetProperties(
				response.Notes,
				response.PrimaryContactEmail,
				response.PrimaryContactFirstName,
				response.PrimaryContactLastName,
				response.PrimaryContactPhone);
			return request;
		}

		public virtual ApiFamilyClientRequestModel MapServerResponseToClientRequest(
			ApiFamilyServerResponseModel response)
		{
			var request = new ApiFamilyClientRequestModel();
			request.SetProperties(
				response.Notes,
				response.PrimaryContactEmail,
				response.PrimaryContactFirstName,
				response.PrimaryContactLastName,
				response.PrimaryContactPhone);
			return request;
		}

		public JsonPatchDocument<ApiFamilyServerRequestModel> CreatePatch(ApiFamilyServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFamilyServerRequestModel>();
			patch.Replace(x => x.Notes, model.Notes);
			patch.Replace(x => x.PrimaryContactEmail, model.PrimaryContactEmail);
			patch.Replace(x => x.PrimaryContactFirstName, model.PrimaryContactFirstName);
			patch.Replace(x => x.PrimaryContactLastName, model.PrimaryContactLastName);
			patch.Replace(x => x.PrimaryContactPhone, model.PrimaryContactPhone);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5dbace7ae13f981e5d66f58979006ace</Hash>
</Codenesium>*/