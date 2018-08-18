using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesOrderDetailMapper
	{
		BOSalesOrderDetail MapModelToBO(
			int salesOrderID,
			ApiSalesOrderDetailRequestModel model);

		ApiSalesOrderDetailResponseModel MapBOToModel(
			BOSalesOrderDetail boSalesOrderDetail);

		List<ApiSalesOrderDetailResponseModel> MapBOToModel(
			List<BOSalesOrderDetail> items);
	}
}

/*<Codenesium>
    <Hash>9b9284332cf47f48bb20280bcedcf01c</Hash>
</Codenesium>*/