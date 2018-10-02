using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public abstract class AbstractApiColumnSameAsFKTableModelMapper
	{
		public virtual ApiColumnSameAsFKTableResponseModel MapRequestToResponse(
			int id,
			ApiColumnSameAsFKTableRequestModel request)
		{
			var response = new ApiColumnSameAsFKTableResponseModel();
			response.SetProperties(id,
			                       request.Person,
			                       request.PersonId);
			return response;
		}

		public virtual ApiColumnSameAsFKTableRequestModel MapResponseToRequest(
			ApiColumnSameAsFKTableResponseModel response)
		{
			var request = new ApiColumnSameAsFKTableRequestModel();
			request.SetProperties(
				response.Person,
				response.PersonId);
			return request;
		}

		public JsonPatchDocument<ApiColumnSameAsFKTableRequestModel> CreatePatch(ApiColumnSameAsFKTableRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiColumnSameAsFKTableRequestModel>();
			patch.Replace(x => x.Person, model.Person);
			patch.Replace(x => x.PersonId, model.PersonId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>595365c7c8352cfb84abe0e444c30d84</Hash>
</Codenesium>*/