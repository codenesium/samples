using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductProductPhotoMapper
	{
		BOProductProductPhoto MapModelToBO(
			int productID,
			ApiProductProductPhotoRequestModel model);

		ApiProductProductPhotoResponseModel MapBOToModel(
			BOProductProductPhoto boProductProductPhoto);

		List<ApiProductProductPhotoResponseModel> MapBOToModel(
			List<BOProductProductPhoto> items);
	}
}

/*<Codenesium>
    <Hash>51e669e1aa398b73203b97dafdbce8da</Hash>
</Codenesium>*/