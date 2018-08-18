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
    <Hash>9706f51b1de274861db65a6953b7f554</Hash>
</Codenesium>*/