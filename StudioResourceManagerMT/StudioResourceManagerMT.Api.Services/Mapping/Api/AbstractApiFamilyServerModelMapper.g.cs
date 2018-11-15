using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerMTNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractApiFamilyServerModelMapper
	{
		public virtual ApiFamilyServerResponseModel MapServerRequestToResponse(
			int id,
			ApiFamilyServerRequestModel request)
		{
			var response = new ApiFamilyServerResponseModel();
			response.SetProperties(id,
			                       request.Note,
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
				response.Note,
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
				response.Note,
				response.PrimaryContactEmail,
				response.PrimaryContactFirstName,
				response.PrimaryContactLastName,
				response.PrimaryContactPhone);
			return request;
		}

		public JsonPatchDocument<ApiFamilyServerRequestModel> CreatePatch(ApiFamilyServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFamilyServerRequestModel>();
			patch.Replace(x => x.Note, model.Note);
			patch.Replace(x => x.PrimaryContactEmail, model.PrimaryContactEmail);
			patch.Replace(x => x.PrimaryContactFirstName, model.PrimaryContactFirstName);
			patch.Replace(x => x.PrimaryContactLastName, model.PrimaryContactLastName);
			patch.Replace(x => x.PrimaryContactPhone, model.PrimaryContactPhone);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4e865eed08067a11926354712b0a0e08</Hash>
</Codenesium>*/