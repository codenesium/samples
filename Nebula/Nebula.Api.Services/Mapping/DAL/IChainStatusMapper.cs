using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public partial interface IDALChainStatusMapper
	{
		ChainStatus MapModelToEntity(
			int id,
			ApiChainStatusServerRequestModel model);

		ApiChainStatusServerResponseModel MapEntityToModel(
			ChainStatus item);

		List<ApiChainStatusServerResponseModel> MapEntityToModel(
			List<ChainStatus> items);
	}
}

/*<Codenesium>
    <Hash>657f0757ed0fe0495692ba1d024c3e9f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/