using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiEventServerModelMapper : IApiEventServerModelMapper
	{
		public virtual ApiEventServerResponseModel MapServerRequestToResponse(
			int id,
			ApiEventServerRequestModel request)
		{
			var response = new ApiEventServerResponseModel();
			response.SetProperties(id,
			                       request.ActualEndDate,
			                       request.ActualStartDate,
			                       request.BillAmount,
			                       request.EventStatusId,
			                       request.ScheduledEndDate,
			                       request.ScheduledStartDate,
			                       request.StudentNotes,
			                       request.TeacherNotes);
			return response;
		}

		public virtual ApiEventServerRequestModel MapServerResponseToRequest(
			ApiEventServerResponseModel response)
		{
			var request = new ApiEventServerRequestModel();
			request.SetProperties(
				response.ActualEndDate,
				response.ActualStartDate,
				response.BillAmount,
				response.EventStatusId,
				response.ScheduledEndDate,
				response.ScheduledStartDate,
				response.StudentNotes,
				response.TeacherNotes);
			return request;
		}

		public virtual ApiEventClientRequestModel MapServerResponseToClientRequest(
			ApiEventServerResponseModel response)
		{
			var request = new ApiEventClientRequestModel();
			request.SetProperties(
				response.ActualEndDate,
				response.ActualStartDate,
				response.BillAmount,
				response.EventStatusId,
				response.ScheduledEndDate,
				response.ScheduledStartDate,
				response.StudentNotes,
				response.TeacherNotes);
			return request;
		}

		public JsonPatchDocument<ApiEventServerRequestModel> CreatePatch(ApiEventServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEventServerRequestModel>();
			patch.Replace(x => x.ActualEndDate, model.ActualEndDate);
			patch.Replace(x => x.ActualStartDate, model.ActualStartDate);
			patch.Replace(x => x.BillAmount, model.BillAmount);
			patch.Replace(x => x.EventStatusId, model.EventStatusId);
			patch.Replace(x => x.ScheduledEndDate, model.ScheduledEndDate);
			patch.Replace(x => x.ScheduledStartDate, model.ScheduledStartDate);
			patch.Replace(x => x.StudentNotes, model.StudentNotes);
			patch.Replace(x => x.TeacherNotes, model.TeacherNotes);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d5b555f12bffdbc2614ea4e170dbd20a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/