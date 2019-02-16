using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductCategoryMapper
	{
		ProductCategory MapModelToBO(
			int productCategoryID,
			ApiProductCategoryServerRequestModel model);

		ApiProductCategoryServerResponseModel MapBOToModel(
			ProductCategory item);

		List<ApiProductCategoryServerResponseModel> MapBOToModel(
			List<ProductCategory> items);
	}
}

/*<Codenesium>
    <Hash>d163d06bc1c94618dbd1f65ed3e6be0a</Hash>
</Codenesium>*/