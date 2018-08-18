using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiScrapReasonModelMapper
	{
		public virtual ApiScrapReasonResponseModel MapRequestToResponse(
			short scrapReasonID,
			ApiScrapReasonRequestModel request)
		{
			var response = new ApiScrapReasonResponseModel();
			response.SetProperties(scrapReasonID,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiScrapReasonRequestModel MapResponseToRequest(
			ApiScrapReasonResponseModel response)
		{
			var request = new ApiScrapReasonRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiScrapReasonRequestModel> CreatePatch(ApiScrapReasonRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiScrapReasonRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4a7a7db4f51418f59a828296944f1dac</Hash>
</Codenesium>*/