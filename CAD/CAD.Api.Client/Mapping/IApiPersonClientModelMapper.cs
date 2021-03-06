using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiPersonModelMapper
	{
		ApiPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPersonClientRequestModel request);

		ApiPersonClientRequestModel MapClientResponseToRequest(
			ApiPersonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>603ed1c5d8a82d6a58765280c943989b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/