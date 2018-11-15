using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLStoreMapper
	{
		BOStore MapModelToBO(
			int businessEntityID,
			ApiStoreServerRequestModel model);

		ApiStoreServerResponseModel MapBOToModel(
			BOStore boStore);

		List<ApiStoreServerResponseModel> MapBOToModel(
			List<BOStore> items);
	}
}

/*<Codenesium>
    <Hash>62c7919a4b86644269be2c198003f0fc</Hash>
</Codenesium>*/