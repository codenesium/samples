using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiUserServerModelMapper
	{
		public virtual ApiUserServerResponseModel MapServerRequestToResponse(
			int userId,
			ApiUserServerRequestModel request)
		{
			var response = new ApiUserServerResponseModel();
			response.SetProperties(userId,
			                       request.BioImgUrl,
			                       request.Birthday,
			                       request.ContentDescription,
			                       request.Email,
			                       request.FullName,
			                       request.HeaderImgUrl,
			                       request.Interest,
			                       request.LocationLocationId,
			                       request.Password,
			                       request.PhoneNumber,
			                       request.Privacy,
			                       request.Username,
			                       request.Website);
			return response;
		}

		public virtual ApiUserServerRequestModel MapServerResponseToRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserServerRequestModel();
			request.SetProperties(
				response.BioImgUrl,
				response.Birthday,
				response.ContentDescription,
				response.Email,
				response.FullName,
				response.HeaderImgUrl,
				response.Interest,
				response.LocationLocationId,
				response.Password,
				response.PhoneNumber,
				response.Privacy,
				response.Username,
				response.Website);
			return request;
		}

		public virtual ApiUserClientRequestModel MapServerResponseToClientRequest(
			ApiUserServerResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.BioImgUrl,
				response.Birthday,
				response.ContentDescription,
				response.Email,
				response.FullName,
				response.HeaderImgUrl,
				response.Interest,
				response.LocationLocationId,
				response.Password,
				response.PhoneNumber,
				response.Privacy,
				response.Username,
				response.Website);
			return request;
		}

		public JsonPatchDocument<ApiUserServerRequestModel> CreatePatch(ApiUserServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUserServerRequestModel>();
			patch.Replace(x => x.BioImgUrl, model.BioImgUrl);
			patch.Replace(x => x.Birthday, model.Birthday);
			patch.Replace(x => x.ContentDescription, model.ContentDescription);
			patch.Replace(x => x.Email, model.Email);
			patch.Replace(x => x.FullName, model.FullName);
			patch.Replace(x => x.HeaderImgUrl, model.HeaderImgUrl);
			patch.Replace(x => x.Interest, model.Interest);
			patch.Replace(x => x.LocationLocationId, model.LocationLocationId);
			patch.Replace(x => x.Password, model.Password);
			patch.Replace(x => x.PhoneNumber, model.PhoneNumber);
			patch.Replace(x => x.Privacy, model.Privacy);
			patch.Replace(x => x.Username, model.Username);
			patch.Replace(x => x.Website, model.Website);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1f836b2835eb0d8333e7802969524ed1</Hash>
</Codenesium>*/