using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IBOLDeviceActionMapper
	{
		DTODeviceAction MapModelToDTO(
			int id,
			ApiDeviceActionRequestModel model);

		ApiDeviceActionResponseModel MapDTOToModel(
			DTODeviceAction dtoDeviceAction);

		List<ApiDeviceActionResponseModel> MapDTOToModel(
			List<DTODeviceAction> dtos);
	}
}

/*<Codenesium>
    <Hash>328aaa25c9bd664b61b8e4c554b2ef2e</Hash>
</Codenesium>*/