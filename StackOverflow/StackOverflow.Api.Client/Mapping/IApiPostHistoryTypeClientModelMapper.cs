using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public partial interface IApiPostHistoryTypeModelMapper
	{
		ApiPostHistoryTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiPostHistoryTypeClientRequestModel request);

		ApiPostHistoryTypeClientRequestModel MapClientResponseToRequest(
			ApiPostHistoryTypeClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>756a35e6c34f87e005c861368b69d132</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/