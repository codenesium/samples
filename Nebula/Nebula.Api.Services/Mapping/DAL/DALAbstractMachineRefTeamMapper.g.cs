using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractMachineRefTeamMapper
	{
		public virtual MachineRefTeam MapBOToEF(
			BOMachineRefTeam bo)
		{
			MachineRefTeam efMachineRefTeam = new MachineRefTeam();
			efMachineRefTeam.SetProperties(
				bo.Id,
				bo.MachineId,
				bo.TeamId);
			return efMachineRefTeam;
		}

		public virtual BOMachineRefTeam MapEFToBO(
			MachineRefTeam ef)
		{
			var bo = new BOMachineRefTeam();

			bo.SetProperties(
				ef.Id,
				ef.MachineId,
				ef.TeamId);
			return bo;
		}

		public virtual List<BOMachineRefTeam> MapEFToBO(
			List<MachineRefTeam> records)
		{
			List<BOMachineRefTeam> response = new List<BOMachineRefTeam>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>30c0cddcbea7b40c8ea175d835bb7030</Hash>
</Codenesium>*/