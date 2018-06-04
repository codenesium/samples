using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
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
			List<BOChainStatus> bos);
	}
}

/*<Codenesium>
    <Hash>306a7853d8504de2f030c89e7ca5cf54</Hash>
</Codenesium>*/