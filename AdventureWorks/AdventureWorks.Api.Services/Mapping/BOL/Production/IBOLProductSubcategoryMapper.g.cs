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
    <Hash>2b709f80f026d5aead326390d1065d6c</Hash>
</Codenesium>*/