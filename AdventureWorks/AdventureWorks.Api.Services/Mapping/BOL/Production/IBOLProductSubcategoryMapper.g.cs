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
			ApiProductSubcategoryServerRequestModel model);

		ApiProductSubcategoryServerResponseModel MapBOToModel(
			BOProductSubcategory boProductSubcategory);

		List<ApiProductSubcategoryServerResponseModel> MapBOToModel(
			List<BOProductSubcategory> items);
	}
}

/*<Codenesium>
    <Hash>cabcaef5a133a8a4bebb8a655359de89</Hash>
</Codenesium>*/