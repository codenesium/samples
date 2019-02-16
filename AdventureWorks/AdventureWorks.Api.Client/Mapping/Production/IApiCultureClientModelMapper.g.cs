using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiCultureModelMapper
	{
		ApiCultureClientResponseModel MapClientRequestToResponse(
			string cultureID,
			ApiCultureClientRequestModel request);

		ApiCultureClientRequestModel MapClientResponseToRequest(
			ApiCultureClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0376eaa4341af5f1c6e28e4e6928fc21</Hash>
</Codenesium>*/