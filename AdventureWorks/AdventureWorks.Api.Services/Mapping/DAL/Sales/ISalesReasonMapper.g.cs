using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALSalesReasonMapper
	{
		SalesReason MapModelToEntity(
			int salesReasonID,
			ApiSalesReasonServerRequestModel model);

		ApiSalesReasonServerResponseModel MapEntityToModel(
			SalesReason item);

		List<ApiSalesReasonServerResponseModel> MapEntityToModel(
			List<SalesReason> items);
	}
}

/*<Codenesium>
    <Hash>801f18ecd414338fd8c6dffc7fb38bb3</Hash>
</Codenesium>*/