using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractInterruptionMapper
	{
		public virtual Interruption MapBOToEF(
			BOInterruption bo)
		{
			Interruption efInterruption = new Interruption();
			efInterruption.SetProperties(
				bo.Created,
				bo.EnvironmentId,
				bo.Id,
				bo.JSON,
				bo.ProjectId,
				bo.RelatedDocumentIds,
				bo.ResponsibleTeamIds,
				bo.Status,
				bo.TaskId,
				bo.TenantId,
				bo.Title);
			return efInterruption;
		}

		public virtual BOInterruption MapEFToBO(
			Interruption ef)
		{
			var bo = new BOInterruption();

			bo.SetProperties(
				ef.Id,
				ef.Created,
				ef.EnvironmentId,
				ef.JSON,
				ef.ProjectId,
				ef.RelatedDocumentIds,
				ef.ResponsibleTeamIds,
				ef.Status,
				ef.TaskId,
				ef.TenantId,
				ef.Title);
			return bo;
		}

		public virtual List<BOInterruption> MapEFToBO(
			List<Interruption> records)
		{
			List<BOInterruption> response = new List<BOInterruption>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ca43aa3110d44f19d8752af071825ac2</Hash>
</Codenesium>*/