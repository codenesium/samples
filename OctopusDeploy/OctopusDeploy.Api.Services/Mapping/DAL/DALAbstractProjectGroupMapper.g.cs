using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractProjectGroupMapper
	{
		public virtual ProjectGroup MapBOToEF(
			BOProjectGroup bo)
		{
			ProjectGroup efProjectGroup = new ProjectGroup();
			efProjectGroup.SetProperties(
				bo.DataVersion,
				bo.Id,
				bo.JSON,
				bo.Name);
			return efProjectGroup;
		}

		public virtual BOProjectGroup MapEFToBO(
			ProjectGroup ef)
		{
			var bo = new BOProjectGroup();

			bo.SetProperties(
				ef.Id,
				ef.DataVersion,
				ef.JSON,
				ef.Name);
			return bo;
		}

		public virtual List<BOProjectGroup> MapEFToBO(
			List<ProjectGroup> records)
		{
			List<BOProjectGroup> response = new List<BOProjectGroup>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>36c5f109d736174e135f537eb8c3c515</Hash>
</Codenesium>*/