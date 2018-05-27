using System;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.DataAccess
{
	public interface IDALDeviceActionMapper
	{
		void MapDTOToEF(
			int id,
			DTODeviceAction dto,
			DeviceAction efDeviceAction);

		DTODeviceAction MapEFToDTO(
			DeviceAction efDeviceAction);
	}
}

/*<Codenesium>
    <Hash>e6bf1158d1383f68905e6a2691bcd874</Hash>
</Codenesium>*/