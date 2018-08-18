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
    <Hash>b19427bdfd4290219153583bf04e773a</Hash>
</Codenesium>*/