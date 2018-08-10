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
    <Hash>7c24ba39d55635324d1392ad30c7b1a4</Hash>
</Codenesium>*/