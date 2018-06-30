using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractWorkerMapper
        {
                public virtual BOWorker MapModelToBO(
                        string id,
                        ApiWorkerRequestModel model
                        )
                {
                        BOWorker boWorker = new BOWorker();
                        boWorker.SetProperties(
                                id,
                                model.CommunicationStyle,
                                model.Fingerprint,
                                model.IsDisabled,
                                model.JSON,
                                model.MachinePolicyId,
                                model.Name,
                                model.RelatedDocumentIds,
                                model.Thumbprint,
                                model.WorkerPoolIds);
                        return boWorker;
                }

                public virtual ApiWorkerResponseModel MapBOToModel(
                        BOWorker boWorker)
                {
                        var model = new ApiWorkerResponseModel();

                        model.SetProperties(boWorker.Id, boWorker.CommunicationStyle, boWorker.Fingerprint, boWorker.IsDisabled, boWorker.JSON, boWorker.MachinePolicyId, boWorker.Name, boWorker.RelatedDocumentIds, boWorker.Thumbprint, boWorker.WorkerPoolIds);

                        return model;
                }

                public virtual List<ApiWorkerResponseModel> MapBOToModel(
                        List<BOWorker> items)
                {
                        List<ApiWorkerResponseModel> response = new List<ApiWorkerResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8802453ab21aae9cc3053eea890122af</Hash>
</Codenesium>*/