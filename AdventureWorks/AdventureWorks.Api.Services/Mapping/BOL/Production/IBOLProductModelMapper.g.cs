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
    <Hash>7c2d23fabb73235da79cbf66982a2c83</Hash>
</Codenesium>*/