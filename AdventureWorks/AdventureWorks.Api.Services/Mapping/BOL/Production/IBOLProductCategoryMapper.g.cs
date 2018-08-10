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
			ApiProductCategoryRequestModel model);

		ApiProductCategoryResponseModel MapBOToModel(
			BOProductCategory boProductCategory);

		List<ApiProductCategoryResponseModel> MapBOToModel(
			List<BOProductCategory> items);
	}
}

/*<Codenesium>
    <Hash>d9d859d9336e42a786e2cd726ca3cd57</Hash>
</Codenesium>*/