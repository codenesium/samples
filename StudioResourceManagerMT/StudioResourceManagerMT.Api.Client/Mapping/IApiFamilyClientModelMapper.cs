using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>34aaeab0a5eb9d487cd65407879742a1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/