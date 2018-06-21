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

                        model.SetProperties(boMachine.CommunicationStyle, boMachine.EnvironmentIds, boMachine.Fingerprint, boMachine.Id, boMachine.IsDisabled, boMachine.JSON, boMachine.MachinePolicyId, boMachine.Name, boMachine.RelatedDocumentIds, boMachine.Roles, boMachine.TenantIds, boMachine.TenantTags, boMachine.Thumbprint);

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
    <Hash>bd6b07ef2f9af77c8c4eefbba37acd5f</Hash>
</Codenesium>*/