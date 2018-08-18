using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLSalesReasonMapper
	{
		BOSalesReason MapModelToBO(
			int salesReasonID,
			ApiSalesReasonRequestModel model);

		ApiSalesReasonResponseModel MapBOToModel(
			BOSalesReason boSalesReason);

		List<ApiSalesReasonResponseModel> MapBOToModel(
			List<BOSalesReason> items);
	}
}

/*<Codenesium>
    <Hash>82f97cd5303192af372c3975e1a6d924</Hash>
</Codenesium>*/