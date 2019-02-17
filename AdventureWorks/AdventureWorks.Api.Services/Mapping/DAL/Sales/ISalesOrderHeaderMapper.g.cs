using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesOrderHeaderMapper
	{
		SalesOrderHeader MapModelToEntity(
			int salesOrderID,
			ApiSalesOrderHeaderServerRequestModel model);

		ApiSalesOrderHeaderServerResponseModel MapEntityToModel(
			SalesOrderHeader item);

		List<ApiSalesOrderHeaderServerResponseModel> MapEntityToModel(
			List<SalesOrderHeader> items);
	}
}

/*<Codenesium>
    <Hash>ed11634068dc20d88a36424d81934f5a</Hash>
</Codenesium>*/