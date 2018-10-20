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
			                       request.ScheduledStartDate,
			                       request.IsDeleted);
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
				response.ScheduledStartDate,
				response.IsDeleted);
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
			patch.Replace(x => x.IsDeleted, model.IsDeleted);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>dc2c11a7ee0574eff02a31454008558a</Hash>
</Codenesium>*/