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
			List<BOSalesPerson> bos);
	}
}

/*<Codenesium>
    <Hash>82b5c3648d70fc38057b8ef7e7e426c2</Hash>
</Codenesium>*/