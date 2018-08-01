using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesPersonMapper
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
    <Hash>35816fa9892d3d727edefb456cd175d4</Hash>
</Codenesium>*/