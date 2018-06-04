using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
			List<BOWorkOrder> bos);
	}
}

/*<Codenesium>
    <Hash>9c5311ae3cd7674139480337b27ff4a1</Hash>
</Codenesium>*/