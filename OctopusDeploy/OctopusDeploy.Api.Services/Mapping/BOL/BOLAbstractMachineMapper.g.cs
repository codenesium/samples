using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractMachineMapper
        {
                public virtual BOMachine MapModelToBO(
                        string id,
                        ApiMachineRequestModel model
                        )
                {
                        BOMachine boMachine = new BOMachine();
                        boMachine.SetProperties(
                                id,
                                model.CommunicationStyle,
                                model.EnvironmentIds,
                                model.Fingerprint,
                                model.IsDisabled,
                                model.JSON,
                                model.MachinePolicyId,
                                model.Name,
                                model.RelatedDocumentIds,
                                model.Roles,
                                model.TenantIds,
                                model.TenantTags,
                                model.Thumbprint);
                        return boMachine;
                }

                public virtual ApiMachineResponseModel MapBOToModel(
                        BOMachine boMachine)
                {
                        var model = new ApiMachineResponseModel();

                        model.SetProperties(boMachine.Id, boMachine.CommunicationStyle, boMachine.EnvironmentIds, boMachine.Fingerprint, boMachine.IsDisabled, boMachine.JSON, boMachine.MachinePolicyId, boMachine.Name, boMachine.RelatedDocumentIds, boMachine.Roles, boMachine.TenantIds, boMachine.TenantTags, boMachine.Thumbprint);

                        return model;
                }

                public virtual List<ApiMachineResponseModel> MapBOToModel(
                        List<BOMachine> items)
                {
                        List<ApiMachineResponseModel> response = new List<ApiMachineResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5f1668026a111338b4b109d90b646e5f</Hash>
</Codenesium>*/