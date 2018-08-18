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
    <Hash>31e483346d6050b0c69182bcb6442846</Hash>
</Codenesium>*/