using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductModelProductDescriptionCultureMapper
	{
		BOProductModelProductDescriptionCulture MapModelToBO(
			int productModelID,
			ApiProductModelProductDescriptionCultureRequestModel model);

		ApiProductModelProductDescriptionCultureResponseModel MapBOToModel(
			BOProductModelProductDescriptionCulture boProductModelProductDescriptionCulture);

		List<ApiProductModelProductDescriptionCultureResponseModel> MapBOToModel(
			List<BOProductModelProductDescriptionCulture> items);
	}
}

/*<Codenesium>
    <Hash>b439bcbfb1fb99595d7fee325c02d5f9</Hash>
</Codenesium>*/