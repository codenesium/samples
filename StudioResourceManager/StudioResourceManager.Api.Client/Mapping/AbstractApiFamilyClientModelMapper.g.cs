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
    <Hash>9dabed49af3459ec516f1b2915de19e6</Hash>
</Codenesium>*/