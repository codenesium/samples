using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductModelMapper
	{
		BOProductModel MapModelToBO(
			int productModelID,
			ApiProductModelRequestModel model);

		ApiProductModelResponseModel MapBOToModel(
			BOProductModel boProductModel);

		List<ApiProductModelResponseModel> MapBOToModel(
			List<BOProductModel> items);
	}
}

/*<Codenesium>
    <Hash>ca517cfcd93a443ba684b89fcdd8251e</Hash>
</Codenesium>*/