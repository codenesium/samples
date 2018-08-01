using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public interface IBOLChainStatusMapper
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
    <Hash>057e99387ac80ee2c352d889f96747cc</Hash>
</Codenesium>*/