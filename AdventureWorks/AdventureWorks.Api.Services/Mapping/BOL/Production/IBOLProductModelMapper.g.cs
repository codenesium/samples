using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductModelMapper
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
    <Hash>e0556388564b942599c6a7b0eb84f5c6</Hash>
</Codenesium>*/