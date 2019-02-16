using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductSubcategoryMapper
	{
		ProductSubcategory MapModelToBO(
			int productSubcategoryID,
			ApiProductSubcategoryServerRequestModel model);

		ApiProductSubcategoryServerResponseModel MapBOToModel(
			ProductSubcategory item);

		List<ApiProductSubcategoryServerResponseModel> MapBOToModel(
			List<ProductSubcategory> items);
	}
}

/*<Codenesium>
    <Hash>55577a31d852dad48bcdbcf02255b4c4</Hash>
</Codenesium>*/