using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductProductPhotoMapper
	{
		ProductProductPhoto MapModelToEntity(
			int productID,
			ApiProductProductPhotoServerRequestModel model);

		ApiProductProductPhotoServerResponseModel MapEntityToModel(
			ProductProductPhoto item);

		List<ApiProductProductPhotoServerResponseModel> MapEntityToModel(
			List<ProductProductPhoto> items);
	}
}

/*<Codenesium>
    <Hash>33882877a13e20c2158b1ae4b2d64401</Hash>
</Codenesium>*/