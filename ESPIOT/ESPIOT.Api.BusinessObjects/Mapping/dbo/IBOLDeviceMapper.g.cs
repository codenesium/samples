using System;
using System.Collections.Generic;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
namespace ESPIOTNS.Api.BusinessObjects
{
	public interface IBOLDeviceMapper
	{
		DTODevice MapModelToDTO(
			int id,
			ApiDeviceRequestModel model);

		ApiDeviceResponseModel MapDTOToModel(
			DTODevice dtoDevice);

		List<ApiDeviceResponseModel> MapDTOToModel(
			List<DTODevice> dtos);
	}
}

/*<Codenesium>
    <Hash>a96ca5cb00863f84c13fcd5066caf4d1</Hash>
</Codenesium>*/