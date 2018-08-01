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
    <Hash>ecff25fb71771a7e3a372a4b7cd0be89</Hash>
</Codenesium>*/