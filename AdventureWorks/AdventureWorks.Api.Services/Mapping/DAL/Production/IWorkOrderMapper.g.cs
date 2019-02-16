using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALWorkOrderMapper
	{
		WorkOrder MapModelToBO(
			int workOrderID,
			ApiWorkOrderServerRequestModel model);

		ApiWorkOrderServerResponseModel MapBOToModel(
			WorkOrder item);

		List<ApiWorkOrderServerResponseModel> MapBOToModel(
			List<WorkOrder> items);
	}
}

/*<Codenesium>
    <Hash>3155a7bce72b5683269375c0f98f47ee</Hash>
</Codenesium>*/