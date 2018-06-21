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
    <Hash>f0ab4dafd7c44a1f7dbf4fa3d0668dcd</Hash>
</Codenesium>*/