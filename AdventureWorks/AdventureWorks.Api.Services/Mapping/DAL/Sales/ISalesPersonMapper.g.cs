using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesPersonMapper
	{
		SalesPerson MapModelToEntity(
			int businessEntityID,
			ApiSalesPersonServerRequestModel model);

		ApiSalesPersonServerResponseModel MapEntityToModel(
			SalesPerson item);

		List<ApiSalesPersonServerResponseModel> MapEntityToModel(
			List<SalesPerson> items);
	}
}

/*<Codenesium>
    <Hash>096cc571aaa516229980c8fa3a1b56a3</Hash>
</Codenesium>*/