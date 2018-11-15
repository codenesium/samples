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
			ApiSalesOrderHeaderServerRequestModel model);

		ApiSalesOrderHeaderServerResponseModel MapBOToModel(
			BOSalesOrderHeader boSalesOrderHeader);

		List<ApiSalesOrderHeaderServerResponseModel> MapBOToModel(
			List<BOSalesOrderHeader> items);
	}
}

/*<Codenesium>
    <Hash>db62eea049500ae5e2f942d12108accb</Hash>
</Codenesium>*/