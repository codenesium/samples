using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesOrderHeaderMapper
	{
		BOSalesOrderHeader MapModelToBO(
			int salesOrderID,
			ApiSalesOrderHeaderRequestModel model);

		ApiSalesOrderHeaderResponseModel MapBOToModel(
			BOSalesOrderHeader boSalesOrderHeader);

		List<ApiSalesOrderHeaderResponseModel> MapBOToModel(
			List<BOSalesOrderHeader> items);
	}
}

/*<Codenesium>
    <Hash>493f25f119ca6e374e7c5dfd3f2e9fb4</Hash>
</Codenesium>*/