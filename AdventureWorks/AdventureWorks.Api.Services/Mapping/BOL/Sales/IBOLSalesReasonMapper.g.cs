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
			ApiSalesReasonServerRequestModel model);

		ApiSalesReasonServerResponseModel MapBOToModel(
			BOSalesReason boSalesReason);

		List<ApiSalesReasonServerResponseModel> MapBOToModel(
			List<BOSalesReason> items);
	}
}

/*<Codenesium>
    <Hash>6809a67826d6a203f6a72f313c5eb3c4</Hash>
</Codenesium>*/