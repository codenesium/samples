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
			List<BOChainStatus> items);
	}
}

/*<Codenesium>
    <Hash>3d450e24c37ebfe6bd02c9271be4a823</Hash>
</Codenesium>*/