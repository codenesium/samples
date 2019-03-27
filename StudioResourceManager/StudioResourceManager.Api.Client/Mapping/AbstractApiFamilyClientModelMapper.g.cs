using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiFamilyModelMapper
	{
		public virtual ApiFamilyClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFamilyClientRequestModel request)
		{
			var response = new ApiFamilyClientResponseModel();
			response.SetProperties(id,
			                       request.Notes,
			                       request.PrimaryContactEmail,
			                       request.PrimaryContactFirstName,
			                       request.PrimaryContactLastName,
			                       request.PrimaryContactPhone);
			return response;
		}

		public virtual ApiFamilyClientRequestModel MapClientResponseToRequest(
			ApiFamilyClientResponseModel response)
		{
			var request = new ApiFamilyClientRequestModel();
			request.SetProperties(
				response.Notes,
				response.PrimaryContactEmail,
				response.PrimaryContactFirstName,
				response.PrimaryContactLastName,
				response.PrimaryContactPhone);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>87ffe2ccbd95301c0c0ff114349ccb68</Hash>
</Codenesium>*/