using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesOrderHeaderMapper
	{
		SalesOrderHeader MapModelToBO(
			int salesOrderID,
			ApiSalesOrderHeaderServerRequestModel model);

		ApiSalesOrderHeaderServerResponseModel MapBOToModel(
			SalesOrderHeader item);

		List<ApiSalesOrderHeaderServerResponseModel> MapBOToModel(
			List<SalesOrderHeader> items);
	}
}

/*<Codenesium>
    <Hash>0d7f633b0eb71068b382562ba77e7791</Hash>
</Codenesium>*/