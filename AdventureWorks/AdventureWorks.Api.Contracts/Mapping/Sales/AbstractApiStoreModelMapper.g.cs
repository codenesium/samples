using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiStoreModelMapper
	{
		public virtual ApiStoreResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiStoreRequestModel request)
		{
			var response = new ApiStoreResponseModel();
			response.SetProperties(businessEntityID,
			                       request.Demographic,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid,
			                       request.SalesPersonID);
			return response;
		}

		public virtual ApiStoreRequestModel MapResponseToRequest(
			ApiStoreResponseModel response)
		{
			var request = new ApiStoreRequestModel();
			request.SetProperties(
				response.Demographic,
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.SalesPersonID);
			return request;
		}

		public JsonPatchDocument<ApiStoreRequestModel> CreatePatch(ApiStoreRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiStoreRequestModel>();
			patch.Replace(x => x.Demographic, model.Demographic);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.SalesPersonID, model.SalesPersonID);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f82a7b564aa6107d6ab1984d71780f10</Hash>
</Codenesium>*/