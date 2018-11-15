using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractTeamMapper
	{
		public virtual Team MapBOToEF(
			BOTeam bo)
		{
			Team efTeam = new Team();
			efTeam.SetProperties(
				bo.Id,
				bo.Name,
				bo.OrganizationId);
			return efTeam;
		}

		public virtual BOTeam MapEFToBO(
			Team ef)
		{
			var bo = new BOTeam();

			bo.SetProperties(
				ef.Id,
				ef.Name,
				ef.OrganizationId);
			return bo;
		}

		public virtual List<BOTeam> MapEFToBO(
			List<Team> records)
		{
			List<BOTeam> response = new List<BOTeam>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7e9e03223e363102ff104cef32c8511f</Hash>
</Codenesium>*/