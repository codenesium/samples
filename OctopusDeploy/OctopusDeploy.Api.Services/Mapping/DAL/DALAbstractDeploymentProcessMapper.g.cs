using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractDeploymentProcessMapper
	{
		public virtual DeploymentProcess MapBOToEF(
			BODeploymentProcess bo)
		{
			DeploymentProcess efDeploymentProcess = new DeploymentProcess();
			efDeploymentProcess.SetProperties(
				bo.Id,
				bo.IsFrozen,
				bo.JSON,
				bo.OwnerId,
				bo.RelatedDocumentIds,
				bo.Version);
			return efDeploymentProcess;
		}

		public virtual BODeploymentProcess MapEFToBO(
			DeploymentProcess ef)
		{
			var bo = new BODeploymentProcess();

			bo.SetProperties(
				ef.Id,
				ef.IsFrozen,
				ef.JSON,
				ef.OwnerId,
				ef.RelatedDocumentIds,
				ef.Version);
			return bo;
		}

		public virtual List<BODeploymentProcess> MapEFToBO(
			List<DeploymentProcess> records)
		{
			List<BODeploymentProcess> response = new List<BODeploymentProcess>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>013e79979d307ad581010fb064936d7d</Hash>
</Codenesium>*/