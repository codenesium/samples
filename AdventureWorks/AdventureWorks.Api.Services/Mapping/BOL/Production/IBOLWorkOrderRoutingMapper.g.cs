using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
			List<BOWorkOrderRouting> bos);
	}
}

/*<Codenesium>
    <Hash>24d8dad561d352d7a3414dce7739c3ca</Hash>
</Codenesium>*/