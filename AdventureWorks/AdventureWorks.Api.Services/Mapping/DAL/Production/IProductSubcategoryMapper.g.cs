using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductSubcategoryMapper
	{
		ProductSubcategory MapModelToEntity(
			int productSubcategoryID,
			ApiProductSubcategoryServerRequestModel model);

		ApiProductSubcategoryServerResponseModel MapEntityToModel(
			ProductSubcategory item);

		List<ApiProductSubcategoryServerResponseModel> MapEntityToModel(
			List<ProductSubcategory> items);
	}
}

/*<Codenesium>
    <Hash>cd787b2c5cd606222fa4558d0d737517</Hash>
</Codenesium>*/