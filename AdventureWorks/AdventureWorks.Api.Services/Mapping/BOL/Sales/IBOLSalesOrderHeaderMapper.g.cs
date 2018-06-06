using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLSalesOrderHeaderMapper
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
    <Hash>06a7ae2b57d69dcb00654b8d91a3b233</Hash>
</Codenesium>*/