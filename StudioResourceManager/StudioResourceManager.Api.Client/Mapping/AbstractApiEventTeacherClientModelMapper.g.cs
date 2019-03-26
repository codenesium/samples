using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiEventTeacherModelMapper
	{
		public virtual ApiEventTeacherClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventTeacherClientRequestModel request)
		{
			var response = new ApiEventTeacherClientResponseModel();
			response.SetProperties(id,
			                       request.TeacherId);
			return response;
		}

		public virtual ApiEventTeacherClientRequestModel MapClientResponseToRequest(
			ApiEventTeacherClientResponseModel response)
		{
			var request = new ApiEventTeacherClientRequestModel();
			request.SetProperties(
				response.TeacherId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ec55bc735cd87a65f37375fc48c57a50</Hash>
</Codenesium>*/