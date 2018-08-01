using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public abstract class AbstractApiVenueModelMapper
	{
		public virtual ApiVenueResponseModel MapRequestToResponse(
			int id,
			ApiVenueRequestModel request)
		{
			var response = new ApiVenueResponseModel();
			response.SetProperties(id,
			                       request.Address1,
			                       request.Address2,
			                       request.AdminId,
			                       request.Email,
			                       request.Facebook,
			                       request.Name,
			                       request.Phone,
			                       request.ProvinceId,
			                       request.Website);
			return response;
		}

		public virtual ApiVenueRequestModel MapResponseToRequest(
			ApiVenueResponseModel response)
		{
			var request = new ApiVenueRequestModel();
			request.SetProperties(
				response.Address1,
				response.Address2,
				response.AdminId,
				response.Email,
				response.Facebook,
				response.Name,
				response.Phone,
				response.ProvinceId,
				response.Website);
			return request;
		}

		public JsonPatchDocument<ApiVenueRequestModel> CreatePatch(ApiVenueRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVenueRequestModel>();
			patch.Replace(x => x.Address1, model.Address1);
			patch.Replace(x => x.Address2, model.Address2);
			patch.Replace(x => x.AdminId, model.AdminId);
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.Facebook, model.Facebook);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Phone, model.Phone);
			patch.Replace(x => x.ProvinceId, model.ProvinceId);
			patch.Replace(x => x.Website, model.Website);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>eec29512d8359e627367c3080ad9f09c</Hash>
</Codenesium>*/