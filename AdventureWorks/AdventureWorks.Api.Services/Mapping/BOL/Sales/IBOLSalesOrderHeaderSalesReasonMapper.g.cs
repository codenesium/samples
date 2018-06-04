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
			List<BOSalesOrderHeaderSalesReason> bos);
	}
}

/*<Codenesium>
    <Hash>5ce9006aa945a4bdd1698dc5c66f71d7</Hash>
</Codenesium>*/