using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractActionTemplateVersionMapper
	{
		public virtual ActionTemplateVersion MapBOToEF(
			BOActionTemplateVersion bo)
		{
			ActionTemplateVersion efActionTemplateVersion = new ActionTemplateVersion();
			efActionTemplateVersion.SetProperties(
				bo.ActionType,
				bo.Id,
				bo.JSON,
				bo.LatestActionTemplateId,
				bo.Name,
				bo.Version);
			return efActionTemplateVersion;
		}

		public virtual BOActionTemplateVersion MapEFToBO(
			ActionTemplateVersion ef)
		{
			var bo = new BOActionTemplateVersion();

			bo.SetProperties(
				ef.Id,
				ef.ActionType,
				ef.JSON,
				ef.LatestActionTemplateId,
				ef.Name,
				ef.Version);
			return bo;
		}

		public virtual List<BOActionTemplateVersion> MapEFToBO(
			List<ActionTemplateVersion> records)
		{
			List<BOActionTemplateVersion> response = new List<BOActionTemplateVersion>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e764225c3f04369f2c9fd1bcf66977f0</Hash>
</Codenesium>*/