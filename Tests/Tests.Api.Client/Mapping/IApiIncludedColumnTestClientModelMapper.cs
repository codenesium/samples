using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Client
{
	public partial interface IApiIncludedColumnTestModelMapper
	{
		ApiIncludedColumnTestClientResponseModel MapClientRequestToResponse(
			int id,
			ApiIncludedColumnTestClientRequestModel request);

		ApiIncludedColumnTestClientRequestModel MapClientResponseToRequest(
			ApiIncludedColumnTestClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>46e21e74794aebfa12ef8dbb29363219</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/