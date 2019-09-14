using FileServiceNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public partial interface IApiFileModelMapper
	{
		ApiFileClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFileClientRequestModel request);

		ApiFileClientRequestModel MapClientResponseToRequest(
			ApiFileClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>e9aa762fcb3ad5125dbc82323869ad28</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/