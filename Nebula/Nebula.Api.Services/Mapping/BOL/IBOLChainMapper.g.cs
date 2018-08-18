using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLChainMapper
	{
		BOChain MapModelToBO(
			int id,
			ApiChainRequestModel model);

		ApiChainResponseModel MapBOToModel(
			BOChain boChain);

		List<ApiChainResponseModel> MapBOToModel(
			List<BOChain> items);
	}
}

/*<Codenesium>
    <Hash>5b63f4ea80c580cba354aa22d160d6bc</Hash>
</Codenesium>*/