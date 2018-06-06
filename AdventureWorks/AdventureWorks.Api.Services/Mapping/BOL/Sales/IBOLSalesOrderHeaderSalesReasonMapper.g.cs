using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesOrderHeaderSalesReasonMapper
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
    <Hash>60c5e9f46c0cde6a90303ea5f327d19f</Hash>
</Codenesium>*/