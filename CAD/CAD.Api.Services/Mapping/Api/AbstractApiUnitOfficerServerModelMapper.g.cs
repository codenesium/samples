using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiUnitOfficerServerModelMapper
	{
		public virtual ApiUnitOfficerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiUnitOfficerServerRequestModel request)
		{
			var response = new ApiUnitOfficerServerResponseModel();
			response.SetProperties(id,
			                       request.OfficerId,
			                       request.UnitId);
			return response;
		}

		public virtual ApiUnitOfficerServerRequestModel MapServerResponseToRequest(
			ApiUnitOfficerServerResponseModel response)
		{
			var request = new ApiUnitOfficerServerRequestModel();
			request.SetProperties(
				response.OfficerId,
				response.UnitId);
			return request;
		}

		public virtual ApiUnitOfficerClientRequestModel MapServerResponseToClientRequest(
			ApiUnitOfficerServerResponseModel response)
		{
			var request = new ApiUnitOfficerClientRequestModel();
			request.SetProperties(
				response.OfficerId,
				response.UnitId);
			return request;
		}

		public JsonPatchDocument<ApiUnitOfficerServerRequestModel> CreatePatch(ApiUnitOfficerServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiUnitOfficerServerRequestModel>();
			patch.Replace(x => x.OfficerId, model.OfficerId);
			patch.Replace(x => x.UnitId, model.UnitId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>67d347fb6ba0f152479ebfec806cf03d</Hash>
</Codenesium>*/