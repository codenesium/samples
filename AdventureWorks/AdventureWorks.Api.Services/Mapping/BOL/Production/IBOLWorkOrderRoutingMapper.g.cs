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
			List<BOWorkOrderRouting> items);
	}
}

/*<Codenesium>
    <Hash>b41ecb72e8789b44c19390327f32910f</Hash>
</Codenesium>*/