using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductPhotoMapper
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
    <Hash>940129f609b5f4dca32c750bbe0a43f3</Hash>
</Codenesium>*/