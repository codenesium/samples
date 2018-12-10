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
			ApiChainServerRequestModel model);

		ApiChainServerResponseModel MapBOToModel(
			BOChain boChain);

		List<ApiChainServerResponseModel> MapBOToModel(
			List<BOChain> items);
	}
}

/*<Codenesium>
    <Hash>d8d6a49e6c4e53ea051c6be7c8fc640a</Hash>
</Codenesium>*/