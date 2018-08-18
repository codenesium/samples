using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractTeamMapper
	{
		public virtual Team MapBOToEF(
			BOTeam bo)
		{
			Team efTeam = new Team();
			efTeam.SetProperties(
				bo.EnvironmentIds,
				bo.Id,
				bo.JSON,
				bo.MemberUserIds,
				bo.Name,
				bo.ProjectGroupIds,
				bo.ProjectIds,
				bo.TenantIds,
				bo.TenantTags);
			return efTeam;
		}

		public virtual BOTeam MapEFToBO(
			Team ef)
		{
			var bo = new BOTeam();

			bo.SetProperties(
				ef.Id,
				ef.EnvironmentIds,
				ef.JSON,
				ef.MemberUserIds,
				ef.Name,
				ef.ProjectGroupIds,
				ef.ProjectIds,
				ef.TenantIds,
				ef.TenantTags);
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
    <Hash>7c22f184c5768c5d3a4e9e36461174bd</Hash>
</Codenesium>*/