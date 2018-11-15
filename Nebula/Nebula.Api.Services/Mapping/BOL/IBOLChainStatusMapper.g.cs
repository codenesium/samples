using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IBOLChainStatusMapper
	{
		BOChainStatus MapModelToBO(
			int id,
			ApiChainStatusServerRequestModel model);

		ApiChainStatusServerResponseModel MapBOToModel(
			BOChainStatus boChainStatus);

		List<ApiChainStatusServerResponseModel> MapBOToModel(
			List<BOChainStatus> items);
	}
}

/*<Codenesium>
    <Hash>24f330640b687d274e3d9d88157ccf8a</Hash>
</Codenesium>*/