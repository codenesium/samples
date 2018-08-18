using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractWorkerTaskLeaseMapper
	{
		public virtual BOWorkerTaskLease MapModelToBO(
			string id,
			ApiWorkerTaskLeaseRequestModel model
			)
		{
			BOWorkerTaskLease boWorkerTaskLease = new BOWorkerTaskLease();
			boWorkerTaskLease.SetProperties(
				id,
				model.Exclusive,
				model.JSON,
				model.Name,
				model.TaskId,
				model.WorkerId);
			return boWorkerTaskLease;
		}

		public virtual ApiWorkerTaskLeaseResponseModel MapBOToModel(
			BOWorkerTaskLease boWorkerTaskLease)
		{
			var model = new ApiWorkerTaskLeaseResponseModel();

			model.SetProperties(boWorkerTaskLease.Id, boWorkerTaskLease.Exclusive, boWorkerTaskLease.JSON, boWorkerTaskLease.Name, boWorkerTaskLease.TaskId, boWorkerTaskLease.WorkerId);

			return model;
		}

		public virtual List<ApiWorkerTaskLeaseResponseModel> MapBOToModel(
			List<BOWorkerTaskLease> items)
		{
			List<ApiWorkerTaskLeaseResponseModel> response = new List<ApiWorkerTaskLeaseResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bc9bd7a573e6814fe9db561a7b291271</Hash>
</Codenesium>*/