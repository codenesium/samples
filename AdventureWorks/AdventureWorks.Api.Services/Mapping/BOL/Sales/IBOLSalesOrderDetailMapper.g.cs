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
    <Hash>96cca8a949a084f7f66a195395aeb941</Hash>
</Codenesium>*/