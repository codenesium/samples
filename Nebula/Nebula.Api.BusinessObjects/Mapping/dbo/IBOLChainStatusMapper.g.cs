using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLChainStatusMapper
	{
		DTOChainStatus MapModelToDTO(
			int id,
			ApiChainStatusRequestModel model);

		ApiChainStatusResponseModel MapDTOToModel(
			DTOChainStatus dtoChainStatus);

		List<ApiChainStatusResponseModel> MapDTOToModel(
			List<DTOChainStatus> dtos);
	}
}

/*<Codenesium>
    <Hash>8f5c9c700ad1bb01a955a5fd90730b1b</Hash>
</Codenesium>*/