using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLWorkOrderMapper
	{
		DTOWorkOrder MapModelToDTO(
			int workOrderID,
			ApiWorkOrderRequestModel model);

		ApiWorkOrderResponseModel MapDTOToModel(
			DTOWorkOrder dtoWorkOrder);

		List<ApiWorkOrderResponseModel> MapDTOToModel(
			List<DTOWorkOrder> dtos);
	}
}

/*<Codenesium>
    <Hash>ff83dbce1155430d351418274c3cb70a</Hash>
</Codenesium>*/