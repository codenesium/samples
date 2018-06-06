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
			List<BOProductProductPhoto> items);
	}
}

/*<Codenesium>
    <Hash>3e4ee3515162da3003ec348aff00c061</Hash>
</Codenesium>*/