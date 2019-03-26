using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductDescriptionMapper
	{
		ProductDescription MapModelToEntity(
			int productDescriptionID,
			ApiProductDescriptionServerRequestModel model);

		ApiProductDescriptionServerResponseModel MapEntityToModel(
			ProductDescription item);

		List<ApiProductDescriptionServerResponseModel> MapEntityToModel(
			List<ProductDescription> items);
	}
}

/*<Codenesium>
    <Hash>2f9b210067130de1e45fc7a67d848511</Hash>
</Codenesium>*/