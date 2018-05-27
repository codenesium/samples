using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALMachineMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOMachine dto,
			Machine efMachine)
		{
			efMachine.SetProperties(
				id,
				dto.Description,
				dto.JwtKey,
				dto.LastIpAddress,
				dto.MachineGuid,
				dto.Name);
		}

		public virtual DTOMachine MapEFToDTO(
			Machine ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOMachine();

			dto.SetProperties(
				ef.Id,
				ef.Description,
				ef.JwtKey,
				ef.LastIpAddress,
				ef.MachineGuid,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>77716f93b9928f7450ee9c7f5b4347c2</Hash>
</Codenesium>*/