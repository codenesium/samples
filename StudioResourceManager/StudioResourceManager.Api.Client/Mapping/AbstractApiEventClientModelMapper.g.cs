using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiEventModelMapper
	{
		public virtual ApiEventClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventClientRequestModel request)
		{
			var response = new ApiEventClientResponseModel();
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

		public virtual ApiEventClientRequestModel MapClientResponseToRequest(
			ApiEventClientResponseModel response)
		{
			var request = new ApiEventClientRequestModel();
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
	}
}

/*<Codenesium>
    <Hash>8d8353fed728908738de8e33e43b8957</Hash>
</Codenesium>*/