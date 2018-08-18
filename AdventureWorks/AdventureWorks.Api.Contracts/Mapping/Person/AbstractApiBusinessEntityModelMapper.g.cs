using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiBusinessEntityModelMapper
	{
		public virtual ApiBusinessEntityResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiBusinessEntityRequestModel request)
		{
			var response = new ApiBusinessEntityResponseModel();
			response.SetProperties(businessEntityID,
			                       request.ModifiedDate,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiBusinessEntityRequestModel MapResponseToRequest(
			ApiBusinessEntityResponseModel response)
		{
			var request = new ApiBusinessEntityRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Rowguid);
			return request;
		}

		public JsonPatchDocument<ApiBusinessEntityRequestModel> CreatePatch(ApiBusinessEntityRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiBusinessEntityRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>242f003f1dc2abaa77422ef48b4719f0</Hash>
</Codenesium>*/