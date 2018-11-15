using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductCategoryMapper
	{
		BOProductCategory MapModelToBO(
			int productCategoryID,
			ApiProductCategoryServerRequestModel model);

		ApiProductCategoryServerResponseModel MapBOToModel(
			BOProductCategory boProductCategory);

		List<ApiProductCategoryServerResponseModel> MapBOToModel(
			List<BOProductCategory> items);
	}
}

/*<Codenesium>
    <Hash>a56a1fc65d4f9bf066bc149c0fa0256b</Hash>
</Codenesium>*/