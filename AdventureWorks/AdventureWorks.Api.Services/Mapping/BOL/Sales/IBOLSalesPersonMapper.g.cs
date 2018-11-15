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
			ApiSalesPersonServerRequestModel model);

		ApiSalesPersonServerResponseModel MapBOToModel(
			BOSalesPerson boSalesPerson);

		List<ApiSalesPersonServerResponseModel> MapBOToModel(
			List<BOSalesPerson> items);
	}
}

/*<Codenesium>
    <Hash>009ce14b53881dbfb7abf59098a28a63</Hash>
</Codenesium>*/