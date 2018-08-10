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
    <Hash>3367f0424b2e164838f7fa3b48509eb0</Hash>
</Codenesium>*/