using AdventureWorksNS.Api.Contracts;
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
    <Hash>3ee1e415d41eb8254a1496ad4a5d0a55</Hash>
</Codenesium>*/