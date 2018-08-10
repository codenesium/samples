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
    <Hash>d3f696a14546c55cabdb8c15f49c5ab0</Hash>
</Codenesium>*/