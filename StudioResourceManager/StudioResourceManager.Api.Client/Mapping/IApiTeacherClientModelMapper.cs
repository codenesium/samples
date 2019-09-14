using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
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
    <Hash>9266f70696ef99e3f2d8fa16c0c779b6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/