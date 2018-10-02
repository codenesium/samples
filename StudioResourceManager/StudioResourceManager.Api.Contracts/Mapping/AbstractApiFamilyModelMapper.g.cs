using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiFamilyModelMapper
	{
		public virtual ApiFamilyResponseModel MapRequestToResponse(
			int id,
			ApiFamilyRequestModel request)
		{
			var response = new ApiFamilyResponseModel();
			response.SetProperties(id,
			                       request.Note,
			                       request.PrimaryContactEmail,
			                       request.PrimaryContactFirstName,
			                       request.PrimaryContactLastName,
			                       request.PrimaryContactPhone);
			return response;
		}

		public virtual ApiFamilyRequestModel MapResponseToRequest(
			ApiFamilyResponseModel response)
		{
			var request = new ApiFamilyRequestModel();
			request.SetProperties(
				response.Note,
				response.PrimaryContactEmail,
				response.PrimaryContactFirstName,
				response.PrimaryContactLastName,
				response.PrimaryContactPhone);
			return request;
		}

		public JsonPatchDocument<ApiFamilyRequestModel> CreatePatch(ApiFamilyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFamilyRequestModel>();
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
    <Hash>7ad97521a0e4fc6155beb9bec187f926</Hash>
</Codenesium>*/