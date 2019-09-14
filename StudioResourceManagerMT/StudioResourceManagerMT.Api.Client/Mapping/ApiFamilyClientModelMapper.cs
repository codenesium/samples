using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public class ApiFamilyModelMapper : IApiFamilyModelMapper
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
    <Hash>6693e4129249ff3f6dd4ba9ca5b4c792</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/