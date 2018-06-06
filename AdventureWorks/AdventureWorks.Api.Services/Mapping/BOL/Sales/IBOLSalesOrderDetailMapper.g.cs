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
			List<BOSalesOrderDetail> items);
	}
}

/*<Codenesium>
    <Hash>90d755d724d728f9cb3a664d8695e2a6</Hash>
</Codenesium>*/