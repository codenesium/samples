using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>0e419985c0d75eeb1da25227abeaf473</Hash>
</Codenesium>*/