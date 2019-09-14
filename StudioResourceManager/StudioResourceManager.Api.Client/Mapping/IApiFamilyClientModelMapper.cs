using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiFamilyModelMapper
	{
		ApiFamilyClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFamilyClientRequestModel request);

		ApiFamilyClientRequestModel MapClientResponseToRequest(
			ApiFamilyClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>16e57918406829d48fccfb0f5e80cf51</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/