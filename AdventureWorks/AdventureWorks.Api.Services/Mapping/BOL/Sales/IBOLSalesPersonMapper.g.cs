using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesPersonMapper
	{
		BOSalesPerson MapModelToBO(
			int businessEntityID,
			ApiSalesPersonRequestModel model);

		ApiSalesPersonResponseModel MapBOToModel(
			BOSalesPerson boSalesPerson);

		List<ApiSalesPersonResponseModel> MapBOToModel(
			List<BOSalesPerson> items);
	}
}

/*<Codenesium>
    <Hash>f517b7cfb5dd6f3e803206f8a9bbbb9a</Hash>
</Codenesium>*/