using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALWorkOrderMapper
	{
		WorkOrder MapModelToEntity(
			int workOrderID,
			ApiWorkOrderServerRequestModel model);

		ApiWorkOrderServerResponseModel MapEntityToModel(
			WorkOrder item);

		List<ApiWorkOrderServerResponseModel> MapEntityToModel(
			List<WorkOrder> items);
	}
}

/*<Codenesium>
    <Hash>dd3e0dd071de06c5e475e5d460950814</Hash>
</Codenesium>*/