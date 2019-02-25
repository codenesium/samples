using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALStoreMapper
	{
		Store MapModelToEntity(
			int businessEntityID,
			ApiStoreServerRequestModel model);

		ApiStoreServerResponseModel MapEntityToModel(
			Store item);

		List<ApiStoreServerResponseModel> MapEntityToModel(
			List<Store> items);
	}
}

/*<Codenesium>
    <Hash>aa6691e6cb37bfa910dad0ab852eb95f</Hash>
</Codenesium>*/