using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public partial interface IApiEventTeacherModelMapper
	{
		ApiEventTeacherClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventTeacherClientRequestModel request);

		ApiEventTeacherClientRequestModel MapClientResponseToRequest(
			ApiEventTeacherClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c40120d30d2f01487ecf800cce6a564f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/