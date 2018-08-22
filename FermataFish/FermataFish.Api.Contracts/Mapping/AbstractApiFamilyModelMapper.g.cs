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
			                       request.Note,
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
				response.Note,
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
			patch.Replace(x => x.Note, model.Note);
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
    <Hash>360a501503e996797c16941ef2f4b2d5</Hash>
</Codenesium>*/