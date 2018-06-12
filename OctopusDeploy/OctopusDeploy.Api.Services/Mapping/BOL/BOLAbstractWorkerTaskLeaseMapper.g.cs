using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                        model.SetProperties(boWorkerTaskLease.Exclusive, boWorkerTaskLease.Id, boWorkerTaskLease.JSON, boWorkerTaskLease.Name, boWorkerTaskLease.TaskId, boWorkerTaskLease.WorkerId);

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
    <Hash>5f4a0d0541901372a6e2724bdd92ff70</Hash>
</Codenesium>*/