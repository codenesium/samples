using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>1747298e996ab95ad5d70ce564a68366</Hash>
</Codenesium>*/