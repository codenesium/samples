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
    <Hash>b5e8df75ce76861cf6a9f6f9830211ca</Hash>
</Codenesium>*/