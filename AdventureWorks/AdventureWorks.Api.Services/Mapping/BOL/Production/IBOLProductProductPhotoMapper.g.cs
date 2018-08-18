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
    <Hash>0c4709992fbb0a9bbe03e9038df65680</Hash>
</Codenesium>*/