using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiShiftModelMapper
	{
		public virtual ApiShiftResponseModel MapRequestToResponse(
			int shiftID,
			ApiShiftRequestModel request)
		{
			var response = new ApiShiftResponseModel();
			response.SetProperties(shiftID,
			                       request.EndTime,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.StartTime);
			return response;
		}

		public virtual ApiShiftRequestModel MapResponseToRequest(
			ApiShiftResponseModel response)
		{
			var request = new ApiShiftRequestModel();
			request.SetProperties(
				response.EndTime,
				response.ModifiedDate,
				response.Name,
				response.StartTime);
			return request;
		}

		public JsonPatchDocument<ApiShiftRequestModel> CreatePatch(ApiShiftRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiShiftRequestModel>();
			patch.Replace(x => x.EndTime, model.EndTime);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.StartTime, model.StartTime);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b36213881e538054d445f3b9cf837d94</Hash>
</Codenesium>*/