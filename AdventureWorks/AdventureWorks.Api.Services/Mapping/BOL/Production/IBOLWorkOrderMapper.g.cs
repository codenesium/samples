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
    <Hash>3466eda64411db8bea64a98a815e2fc0</Hash>
</Codenesium>*/