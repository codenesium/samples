using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLWorkOrderRoutingMapper
	{
		DTOWorkOrderRouting MapModelToDTO(
			int workOrderID,
			ApiWorkOrderRoutingRequestModel model);

		ApiWorkOrderRoutingResponseModel MapDTOToModel(
			DTOWorkOrderRouting dtoWorkOrderRouting);

		List<ApiWorkOrderRoutingResponseModel> MapDTOToModel(
			List<DTOWorkOrderRouting> dtos);
	}
}

/*<Codenesium>
    <Hash>704a394024722cebf438ce29c1cffeb4</Hash>
</Codenesium>*/