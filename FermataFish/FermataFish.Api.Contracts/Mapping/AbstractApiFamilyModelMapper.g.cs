using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
	public abstract class AbstractApiFamilyModelMapper
	{
		public virtual ApiFamilyResponseModel MapRequestToResponse(
			int id,
			ApiFamilyRequestModel request)
		{
			var response = new ApiFamilyResponseModel();
			response.SetProperties(id,
			                       request.Notes,
			                       request.PcEmail,
			                       request.PcFirstName,
			                       request.PcLastName,
			                       request.PcPhone,
			                       request.StudioId);
			return response;
		}

		public virtual ApiFamilyRequestModel MapResponseToRequest(
			ApiFamilyResponseModel response)
		{
			var request = new ApiFamilyRequestModel();
			request.SetProperties(
				response.Notes,
				response.PcEmail,
				response.PcFirstName,
				response.PcLastName,
				response.PcPhone,
				response.StudioId);
			return request;
		}

		public JsonPatchDocument<ApiFamilyRequestModel> CreatePatch(ApiFamilyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiFamilyRequestModel>();
			patch.Replace(x => x.Notes, model.Notes);
			patch.Replace(x => x.PcEmail, model.PcEmail);
			patch.Replace(x => x.PcFirstName, model.PcFirstName);
			patch.Replace(x => x.PcLastName, model.PcLastName);
			patch.Replace(x => x.PcPhone, model.PcPhone);
			patch.Replace(x => x.StudioId, model.StudioId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>78edebf875e65ef019740a4be6cc2e40</Hash>
</Codenesium>*/