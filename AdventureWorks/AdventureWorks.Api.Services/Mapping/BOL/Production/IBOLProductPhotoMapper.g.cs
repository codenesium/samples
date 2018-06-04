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
			List<BOProductPhoto> bos);
	}
}

/*<Codenesium>
    <Hash>ced62a481ea1f58118ad3f11a79d689d</Hash>
</Codenesium>*/