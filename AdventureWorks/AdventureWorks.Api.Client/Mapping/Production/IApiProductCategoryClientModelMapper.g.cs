using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductCategoryModelMapper
	{
		ApiProductCategoryClientResponseModel MapClientRequestToResponse(
			int productCategoryID,
			ApiProductCategoryClientRequestModel request);

		ApiProductCategoryClientRequestModel MapClientResponseToRequest(
			ApiProductCategoryClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>69140a59344b19b5a8883aa6089349a1</Hash>
</Codenesium>*/