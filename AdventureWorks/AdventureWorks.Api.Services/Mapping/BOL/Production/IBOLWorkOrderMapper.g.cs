using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLWorkOrderMapper
	{
		BOWorkOrder MapModelToBO(
			int workOrderID,
			ApiWorkOrderRequestModel model);

		ApiWorkOrderResponseModel MapBOToModel(
			BOWorkOrder boWorkOrder);

		List<ApiWorkOrderResponseModel> MapBOToModel(
			List<BOWorkOrder> items);
	}
}

/*<Codenesium>
    <Hash>f2a5645696d27524c2c2999a43858344</Hash>
</Codenesium>*/