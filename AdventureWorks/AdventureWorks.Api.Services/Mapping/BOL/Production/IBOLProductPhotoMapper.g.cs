using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductPhotoMapper
	{
		BOProductPhoto MapModelToBO(
			int productPhotoID,
			ApiProductPhotoRequestModel model);

		ApiProductPhotoResponseModel MapBOToModel(
			BOProductPhoto boProductPhoto);

		List<ApiProductPhotoResponseModel> MapBOToModel(
			List<BOProductPhoto> items);
	}
}

/*<Codenesium>
    <Hash>3681959e46542c2c264f1e728a295569</Hash>
</Codenesium>*/