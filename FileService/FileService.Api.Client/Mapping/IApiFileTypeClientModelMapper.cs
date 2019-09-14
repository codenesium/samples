using FileServiceNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
{
	public partial interface IApiFileTypeModelMapper
	{
		ApiFileTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiFileTypeClientRequestModel request);

		ApiFileTypeClientRequestModel MapClientResponseToRequest(
			ApiFileTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>cf7ba24cc94e525da941df23df19ef5f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/