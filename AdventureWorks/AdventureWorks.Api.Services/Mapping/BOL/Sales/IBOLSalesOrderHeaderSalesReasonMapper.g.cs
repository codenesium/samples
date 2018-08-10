using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesOrderHeaderSalesReasonMapper
	{
		BOSalesOrderHeaderSalesReason MapModelToBO(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel model);

		ApiSalesOrderHeaderSalesReasonResponseModel MapBOToModel(
			BOSalesOrderHeaderSalesReason boSalesOrderHeaderSalesReason);

		List<ApiSalesOrderHeaderSalesReasonResponseModel> MapBOToModel(
			List<BOSalesOrderHeaderSalesReason> items);
	}
}

/*<Codenesium>
    <Hash>806deab82b4d6c9fae86ec8c7753c7ac</Hash>
</Codenesium>*/