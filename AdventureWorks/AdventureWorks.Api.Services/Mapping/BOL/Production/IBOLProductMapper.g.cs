using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLProductMapper
	{
		BOProduct MapModelToBO(
			int productID,
			ApiProductRequestModel model);

		ApiProductResponseModel MapBOToModel(
			BOProduct boProduct);

		List<ApiProductResponseModel> MapBOToModel(
			List<BOProduct> items);
	}
}

/*<Codenesium>
    <Hash>aa7014bb1e6a983a05dde7b88d5c0dd4</Hash>
</Codenesium>*/