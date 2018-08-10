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
			ApiStoreRequestModel model);

		ApiStoreResponseModel MapBOToModel(
			BOStore boStore);

		List<ApiStoreResponseModel> MapBOToModel(
			List<BOStore> items);
	}
}

/*<Codenesium>
    <Hash>30773609e50e7e75eb270631e2e2e1af</Hash>
</Codenesium>*/