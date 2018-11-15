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
			ApiProductPhotoServerRequestModel model);

		ApiProductPhotoServerResponseModel MapBOToModel(
			BOProductPhoto boProductPhoto);

		List<ApiProductPhotoServerResponseModel> MapBOToModel(
			List<BOProductPhoto> items);
	}
}

/*<Codenesium>
    <Hash>eaf47492fa17036d97c24f1de69d3020</Hash>
</Codenesium>*/