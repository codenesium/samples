using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductProductPhotoMapper
	{
		BOProductProductPhoto MapModelToBO(
			int productID,
			ApiProductProductPhotoRequestModel model);

		ApiProductProductPhotoResponseModel MapBOToModel(
			BOProductProductPhoto boProductProductPhoto);

		List<ApiProductProductPhotoResponseModel> MapBOToModel(
			List<BOProductProductPhoto> bos);
	}
}

/*<Codenesium>
    <Hash>73c32d1221cf548821dd997d471f2440</Hash>
</Codenesium>*/