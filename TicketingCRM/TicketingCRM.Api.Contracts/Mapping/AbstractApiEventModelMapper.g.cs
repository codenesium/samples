using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiEventModelMapper
	{
		public virtual ApiEventResponseModel MapRequestToResponse(
			int id,
			ApiEventRequestModel request)
		{
			var response = new ApiEventResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.CityId,
			                       request.Date,
			                       request.Description,
			                       request.EndDate,
			                       request.Facebook,
			                       request.Name,
			                       request.StartDate,
			                       request.Website);
			return response;
		}

		public virtual ApiEventRequestModel MapResponseToRequest(
			ApiEventResponseModel response)
		{
			var request = new ApiEventRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.CityId,
				response.Date,
				response.Description,
				response.EndDate,
				response.Facebook,
				response.Name,
				response.StartDate,
				response.Website);
			return request;
		}

		public JsonPatchDocument<ApiEventRequestModel> CreatePatch(ApiEventRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventRequestModel>();
			patch.Replace(x => x.Address1, model.Address1);
			patch.Replace(x => x.Address2, model.Address2);
			patch.Replace(x => x.CityId, model.CityId);
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.EndDate, model.EndDate);
			patch.Replace(x => x.Facebook, model.Facebook);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.StartDate, model.StartDate);
			patch.Replace(x => x.Website, model.Website);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>44cc99646d56300a8a71546c31c2e293</Hash>
</Codenesium>*/