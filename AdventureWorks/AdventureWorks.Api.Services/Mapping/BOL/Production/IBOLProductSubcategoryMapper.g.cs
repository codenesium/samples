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
			List<BOProductSubcategory> bos);
	}
}

/*<Codenesium>
    <Hash>e0a0f7e3b0695bae4e2f179282bb3a41</Hash>
</Codenesium>*/