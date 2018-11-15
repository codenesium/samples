using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiProductSubcategoryModelMapper
	{
		ApiProductSubcategoryClientResponseModel MapClientRequestToResponse(
			int productSubcategoryID,
			ApiProductSubcategoryClientRequestModel request);

		ApiProductSubcategoryClientRequestModel MapClientResponseToRequest(
			ApiProductSubcategoryClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d54c6c5ed2f46be9dcdb1f8f9fa0f4bc</Hash>
</Codenesium>*/