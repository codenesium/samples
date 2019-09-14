using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial interface IApiTeacherModelMapper
	{
		ApiTeacherClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTeacherClientRequestModel request);

		ApiTeacherClientRequestModel MapClientResponseToRequest(
			ApiTeacherClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5b2bf528c00f49e7d218e20b878e817f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/