using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLWorkOrderRoutingMapper
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
    <Hash>8fc40abfbcb6fa0aba381215f45a5929</Hash>
</Codenesium>*/