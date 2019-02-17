using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductCategoryMapper
	{
		ProductCategory MapModelToEntity(
			int productCategoryID,
			ApiProductCategoryServerRequestModel model);

		ApiProductCategoryServerResponseModel MapEntityToModel(
			ProductCategory item);

		List<ApiProductCategoryServerResponseModel> MapEntityToModel(
			List<ProductCategory> items);
	}
}

/*<Codenesium>
    <Hash>734e57b43b2809f8ad4da7e78bd648ea</Hash>
</Codenesium>*/