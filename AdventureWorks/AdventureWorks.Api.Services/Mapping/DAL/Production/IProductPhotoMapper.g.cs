using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductPhotoMapper
	{
		ProductPhoto MapModelToEntity(
			int productPhotoID,
			ApiProductPhotoServerRequestModel model);

		ApiProductPhotoServerResponseModel MapEntityToModel(
			ProductPhoto item);

		List<ApiProductPhotoServerResponseModel> MapEntityToModel(
			List<ProductPhoto> items);
	}
}

/*<Codenesium>
    <Hash>6b72e33a9ee77c9f713a2563c5de62f4</Hash>
</Codenesium>*/