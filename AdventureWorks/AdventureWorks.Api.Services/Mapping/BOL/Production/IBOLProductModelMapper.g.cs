using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductModelMapper
	{
		BOProductModel MapModelToBO(
			int productModelID,
			ApiProductModelServerRequestModel model);

		ApiProductModelServerResponseModel MapBOToModel(
			BOProductModel boProductModel);

		List<ApiProductModelServerResponseModel> MapBOToModel(
			List<BOProductModel> items);
	}
}

/*<Codenesium>
    <Hash>16254dfc8ca854cdc3c1b1016ac41f5b</Hash>
</Codenesium>*/