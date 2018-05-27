using System;
using Microsoft.EntityFrameworkCore;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.DataAccess
{
	public abstract class AbstractDALDeviceMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTODevice dto,
			Device efDevice)
		{
			efDevice.SetProperties(
				id,
				dto.Name,
				dto.PublicId);
		}

		public virtual DTODevice MapEFToDTO(
			Device ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTODevice();

			dto.SetProperties(
				ef.Id,
				ef.Name,
				ef.PublicId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>f9fe45eb6472ca4905fa05e1f042f938</Hash>
</Codenesium>*/