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
    <Hash>6e84dbbfbc9d932d4ff2da69753cfe1e</Hash>
</Codenesium>*/