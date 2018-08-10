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
    <Hash>54aa3e094cd81a51a4747661e0dd374a</Hash>
</Codenesium>*/