using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALProductDescriptionMapper
	{
		ProductDescription MapModelToBO(
			int productDescriptionID,
			ApiProductDescriptionServerRequestModel model);

		ApiProductDescriptionServerResponseModel MapBOToModel(
			ProductDescription item);

		List<ApiProductDescriptionServerResponseModel> MapBOToModel(
			List<ProductDescription> items);
	}
}

/*<Codenesium>
    <Hash>eb53af0e2a70f39862c92b17eb7556d0</Hash>
</Codenesium>*/