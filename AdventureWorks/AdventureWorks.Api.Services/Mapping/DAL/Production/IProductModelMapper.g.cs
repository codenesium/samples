using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductModelMapper
	{
		ProductModel MapModelToBO(
			int productModelID,
			ApiProductModelServerRequestModel model);

		ApiProductModelServerResponseModel MapBOToModel(
			ProductModel item);

		List<ApiProductModelServerResponseModel> MapBOToModel(
			List<ProductModel> items);
	}
}

/*<Codenesium>
    <Hash>054dc3801336111bd1e402f022628977</Hash>
</Codenesium>*/