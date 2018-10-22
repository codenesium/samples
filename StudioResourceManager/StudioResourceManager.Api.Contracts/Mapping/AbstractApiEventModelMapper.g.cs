using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Contracts
{
	public abstract class AbstractApiEventModelMapper
	{
		public virtual ApiEventResponseModel MapRequestToResponse(
			int id,
			ApiEventRequestModel request)
		{
			var response = new ApiEventResponseModel();
			response.SetProperties(id,
			                       request.ActualEndDate,
			                       request.ActualStartDate,
			                       request.BillAmount,
			                       request.EventStatusId,
			                       request.ScheduledEndDate,
			                       request.ScheduledStartDate,
			                       request.StudentNote,
			                       request.TeacherNote);
			return response;
		}

		public virtual ApiEventRequestModel MapResponseToRequest(
			ApiEventResponseModel response)
		{
			var request = new ApiEventRequestModel();
			request.SetProperties(
				response.ActualEndDate,
				response.ActualStartDate,
				response.BillAmount,
				response.EventStatusId,
				response.ScheduledEndDate,
				response.ScheduledStartDate,
				response.StudentNote,
				response.TeacherNote);
			return request;
		}

		public JsonPatchDocument<ApiEventRequestModel> CreatePatch(ApiEventRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventRequestModel>();
			patch.Replace(x => x.ActualEndDate, model.ActualEndDate);
			patch.Replace(x => x.ActualStartDate, model.ActualStartDate);
			patch.Replace(x => x.BillAmount, model.BillAmount);
			patch.Replace(x => x.EventStatusId, model.EventStatusId);
			patch.Replace(x => x.ScheduledEndDate, model.ScheduledEndDate);
			patch.Replace(x => x.ScheduledStartDate, model.ScheduledStartDate);
			patch.Replace(x => x.StudentNote, model.StudentNote);
			patch.Replace(x => x.TeacherNote, model.TeacherNote);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a8129103ee86a8921edb7590caf3dd28</Hash>
</Codenesium>*/