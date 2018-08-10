using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductSubcategoryMapper
	{
		BOProductSubcategory MapModelToBO(
			int productSubcategoryID,
			ApiProductSubcategoryRequestModel model);

		ApiProductSubcategoryResponseModel MapBOToModel(
			BOProductSubcategory boProductSubcategory);

		List<ApiProductSubcategoryResponseModel> MapBOToModel(
			List<BOProductSubcategory> items);
	}
}

/*<Codenesium>
    <Hash>d8dc39bd70cac36ec5042a28a57376c1</Hash>
</Codenesium>*/