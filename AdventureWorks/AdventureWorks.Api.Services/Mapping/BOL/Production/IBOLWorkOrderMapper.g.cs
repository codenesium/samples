using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLWorkOrderMapper
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
    <Hash>fb34330a4a4afb7f65333146078b0df1</Hash>
</Codenesium>*/