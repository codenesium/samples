using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesPersonMapper
	{
		SalesPerson MapModelToBO(
			int businessEntityID,
			ApiSalesPersonServerRequestModel model);

		ApiSalesPersonServerResponseModel MapBOToModel(
			SalesPerson item);

		List<ApiSalesPersonServerResponseModel> MapBOToModel(
			List<SalesPerson> items);
	}
}

/*<Codenesium>
    <Hash>b847c262dac59d9be54aea8ade7e47e1</Hash>
</Codenesium>*/