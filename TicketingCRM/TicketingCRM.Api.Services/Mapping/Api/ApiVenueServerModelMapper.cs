using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Client;

namespace TicketingCRMNS.Api.Services
{
	public class ApiVenueServerModelMapper : IApiVenueServerModelMapper
	{
		public virtual ApiVenueServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVenueServerRequestModel request)
		{
			var response = new ApiVenueServerResponseModel();
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

		public virtual ApiVenueServerRequestModel MapServerResponseToRequest(
			ApiVenueServerResponseModel response)
		{
			var request = new ApiVenueServerRequestModel();
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

		public virtual ApiVenueClientRequestModel MapServerResponseToClientRequest(
			ApiVenueServerResponseModel response)
		{
			var request = new ApiVenueClientRequestModel();
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

		public JsonPatchDocument<ApiVenueServerRequestModel> CreatePatch(ApiVenueServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVenueServerRequestModel>();
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
    <Hash>64fc9b05546d6e4254a842509c94e755</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/