using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public abstract class AbstractApiFamilyModelMapper
	{
		public virtual ApiFamilyClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFamilyClientRequestModel request)
		{
			var response = new ApiFamilyClientResponseModel();
			response.SetProperties(id,
			                       request.Note,
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
				response.Note,
				response.PrimaryContactEmail,
				response.PrimaryContactFirstName,
				response.PrimaryContactLastName,
				response.PrimaryContactPhone);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d65a9a66b58c510e992d67dbf89330b2</Hash>
</Codenesium>*/