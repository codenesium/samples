using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiVEventModelMapper
	{
		public virtual ApiVEventResponseModel MapRequestToResponse(
			int id,
			ApiVEventRequestModel request)
		{
			var response = new ApiVEventResponseModel();
			response.SetProperties(id,
			                       request.ActualEndDate,
			                       request.ActualStartDate,
			                       request.BillAmount,
			                       request.EventStatusId,
			                       request.ScheduledEndDate,
			                       request.ScheduledStartDate);
			return response;
		}

		public virtual ApiVEventRequestModel MapResponseToRequest(
			ApiVEventResponseModel response)
		{
			var request = new ApiVEventRequestModel();
			request.SetProperties(
				response.ActualEndDate,
				response.ActualStartDate,
				response.BillAmount,
				response.EventStatusId,
				response.ScheduledEndDate,
				response.ScheduledStartDate);
			return request;
		}

		public JsonPatchDocument<ApiVEventRequestModel> CreatePatch(ApiVEventRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVEventRequestModel>();
			patch.Replace(x => x.ActualEndDate, model.ActualEndDate);
			patch.Replace(x => x.ActualStartDate, model.ActualStartDate);
			patch.Replace(x => x.BillAmount, model.BillAmount);
			patch.Replace(x => x.EventStatusId, model.EventStatusId);
			patch.Replace(x => x.ScheduledEndDate, model.ScheduledEndDate);
			patch.Replace(x => x.ScheduledStartDate, model.ScheduledStartDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>605c122718210e37fc02449b742e1108</Hash>
</Codenesium>*/