using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductSubcategoryMapper
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
    <Hash>aacd19d61378a443fe6db798873e8822</Hash>
</Codenesium>*/