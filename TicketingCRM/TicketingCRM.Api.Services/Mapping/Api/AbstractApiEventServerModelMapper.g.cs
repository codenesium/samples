using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiEventServerModelMapper
	{
		public virtual ApiEventServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventServerRequestModel request)
		{
			var response = new ApiEventServerResponseModel();
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

		public virtual ApiEventServerRequestModel MapServerResponseToRequest(
			ApiEventServerResponseModel response)
		{
			var request = new ApiEventServerRequestModel();
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

		public virtual ApiEventClientRequestModel MapServerResponseToClientRequest(
			ApiEventServerResponseModel response)
		{
			var request = new ApiEventClientRequestModel();
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

		public JsonPatchDocument<ApiEventServerRequestModel> CreatePatch(ApiEventServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventServerRequestModel>();
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
    <Hash>4e7c3c9e6a60913a7afac128816b56b4</Hash>
</Codenesium>*/