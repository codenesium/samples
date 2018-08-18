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
    <Hash>87b79d528df2e1b994342e16ab5d01c9</Hash>
</Codenesium>*/