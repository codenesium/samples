using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>94144719c45a1a816b3825f96363e770</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/