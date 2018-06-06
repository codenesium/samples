using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>646d4eeefb9b502f3be2719407b1fd7f</Hash>
</Codenesium>*/