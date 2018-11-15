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
			ApiWorkOrderServerRequestModel model);

		ApiWorkOrderServerResponseModel MapBOToModel(
			BOWorkOrder boWorkOrder);

		List<ApiWorkOrderServerResponseModel> MapBOToModel(
			List<BOWorkOrder> items);
	}
}

/*<Codenesium>
    <Hash>10199d1c881b536fe58057c03b79ec6c</Hash>
</Codenesium>*/