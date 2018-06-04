using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesOrderDetailMapper
	{
		BOSalesOrderDetail MapModelToBO(
			int salesOrderID,
			ApiSalesOrderDetailRequestModel model);

		ApiSalesOrderDetailResponseModel MapBOToModel(
			BOSalesOrderDetail boSalesOrderDetail);

		List<ApiSalesOrderDetailResponseModel> MapBOToModel(
			List<BOSalesOrderDetail> bos);
	}
}

/*<Codenesium>
    <Hash>e12d1fa6dff74efa0c3b6702c4a30ca7</Hash>
</Codenesium>*/