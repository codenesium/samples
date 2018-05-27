using System;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.DataAccess
{
	public abstract class AbstractDALDeviceActionMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTODeviceAction dto,
			DeviceAction efDeviceAction)
		{
			efDeviceAction.SetProperties(
				id,
				dto.DeviceId,
				dto.Name,
				dto.@Value);
		}

		public virtual DTODeviceAction MapEFToDTO(
			DeviceAction ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTODeviceAction();

			dto.SetProperties(
				ef.Id,
				ef.DeviceId,
				ef.Name,
				ef.@Value);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>bca490eb1d11378a2a2affb6cbbf1caa</Hash>
</Codenesium>*/