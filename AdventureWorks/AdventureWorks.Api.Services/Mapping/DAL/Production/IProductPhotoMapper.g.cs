using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductPhotoMapper
	{
		ProductPhoto MapModelToBO(
			int productPhotoID,
			ApiProductPhotoServerRequestModel model);

		ApiProductPhotoServerResponseModel MapBOToModel(
			ProductPhoto item);

		List<ApiProductPhotoServerResponseModel> MapBOToModel(
			List<ProductPhoto> items);
	}
}

/*<Codenesium>
    <Hash>fb514dabdd8d13d73938bd00d2c91d60</Hash>
</Codenesium>*/