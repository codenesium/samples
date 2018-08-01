using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductCategoryMapper
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
    <Hash>df1cd09e6fa5770ccf9fbb02e2da0132</Hash>
</Codenesium>*/