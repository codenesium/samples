using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public class ApiEventModelMapper : IApiEventModelMapper
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
			                       request.StudentNotes,
			                       request.TeacherNotes);
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
				response.StudentNotes,
				response.TeacherNotes);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>30a28cf087041b2630940f75d89b97cb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/