using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiPersonTypeModelMapper
	{
		ApiPersonTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPersonTypeClientRequestModel request);

		ApiPersonTypeClientRequestModel MapClientResponseToRequest(
			ApiPersonTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>571cc248c7a22ba139f3a974ef1ef642</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/