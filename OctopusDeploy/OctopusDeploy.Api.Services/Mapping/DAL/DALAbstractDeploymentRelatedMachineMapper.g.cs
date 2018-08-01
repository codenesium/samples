using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractDeploymentRelatedMachineMapper
	{
		public virtual DeploymentRelatedMachine MapBOToEF(
			BODeploymentRelatedMachine bo)
		{
			DeploymentRelatedMachine efDeploymentRelatedMachine = new DeploymentRelatedMachine();
			efDeploymentRelatedMachine.SetProperties(
				bo.DeploymentId,
				bo.Id,
				bo.MachineId);
			return efDeploymentRelatedMachine;
		}

		public virtual BODeploymentRelatedMachine MapEFToBO(
			DeploymentRelatedMachine ef)
		{
			var bo = new BODeploymentRelatedMachine();

			bo.SetProperties(
				ef.Id,
				ef.DeploymentId,
				ef.MachineId);
			return bo;
		}

		public virtual List<BODeploymentRelatedMachine> MapEFToBO(
			List<DeploymentRelatedMachine> records)
		{
			List<BODeploymentRelatedMachine> response = new List<BODeploymentRelatedMachine>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f000849877bcb1f44ac26b2d38d36be2</Hash>
</Codenesium>*/