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
			List<BOWorkOrder> items);
	}
}

/*<Codenesium>
    <Hash>66300d0a313112fcc546dd55f35ee818</Hash>
</Codenesium>*/