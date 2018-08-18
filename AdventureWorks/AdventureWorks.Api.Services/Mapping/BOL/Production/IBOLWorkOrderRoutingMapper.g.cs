using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLWorkOrderRoutingMapper
	{
		BOWorkOrderRouting MapModelToBO(
			int workOrderID,
			ApiWorkOrderRoutingRequestModel model);

		ApiWorkOrderRoutingResponseModel MapBOToModel(
			BOWorkOrderRouting boWorkOrderRouting);

		List<ApiWorkOrderRoutingResponseModel> MapBOToModel(
			List<BOWorkOrderRouting> items);
	}
}

/*<Codenesium>
    <Hash>afa8be879141ee4c8b315cf4b94fe981</Hash>
</Codenesium>*/