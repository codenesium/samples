using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractDALMachineRefTeamMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOMachineRefTeam dto,
			MachineRefTeam efMachineRefTeam)
		{
			efMachineRefTeam.SetProperties(
				id,
				dto.MachineId,
				dto.TeamId);
		}

		public virtual DTOMachineRefTeam MapEFToDTO(
			MachineRefTeam ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOMachineRefTeam();

			dto.SetProperties(
				ef.Id,
				ef.MachineId,
				ef.TeamId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>b8389494f42bcb70dc670201154aaa38</Hash>
</Codenesium>*/