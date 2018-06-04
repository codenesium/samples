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
			List<BOSalesOrderHeader> bos);
	}
}

/*<Codenesium>
    <Hash>06b8dfe912c122dfe3f38e507f3af825</Hash>
</Codenesium>*/