using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductMapper
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
    <Hash>cd5593492a1b07319ad2633819ce500f</Hash>
</Codenesium>*/