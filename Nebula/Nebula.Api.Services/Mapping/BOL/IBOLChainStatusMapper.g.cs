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
			ApiChainStatusRequestModel model);

		ApiChainStatusResponseModel MapBOToModel(
			BOChainStatus boChainStatus);

		List<ApiChainStatusResponseModel> MapBOToModel(
			List<BOChainStatus> items);
	}
}

/*<Codenesium>
    <Hash>3b1288e55a85486519d7f50a3d2a24c9</Hash>
</Codenesium>*/