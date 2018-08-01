using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>106fef76935d9065f799b3fcd90242f0</Hash>
</Codenesium>*/