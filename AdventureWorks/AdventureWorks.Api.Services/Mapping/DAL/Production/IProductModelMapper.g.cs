using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductModelMapper
	{
		ProductModel MapModelToEntity(
			int productModelID,
			ApiProductModelServerRequestModel model);

		ApiProductModelServerResponseModel MapEntityToModel(
			ProductModel item);

		List<ApiProductModelServerResponseModel> MapEntityToModel(
			List<ProductModel> items);
	}
}

/*<Codenesium>
    <Hash>6bf4ac10352d90bc9b762aebdcdc09d7</Hash>
</Codenesium>*/