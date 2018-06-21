using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractTenantVariableMapper
        {
                public virtual BOTenantVariable MapModelToBO(
                        string id,
                        ApiTenantVariableRequestModel model
                        )
                {
                        BOTenantVariable boTenantVariable = new BOTenantVariable();
                        boTenantVariable.SetProperties(
                                id,
                                model.EnvironmentId,
                                model.JSON,
                                model.OwnerId,
                                model.RelatedDocumentId,
                                model.TenantId,
                                model.VariableTemplateId);
                        return boTenantVariable;
                }

                public virtual ApiTenantVariableResponseModel MapBOToModel(
                        BOTenantVariable boTenantVariable)
                {
                        var model = new ApiTenantVariableResponseModel();

                        model.SetProperties(boTenantVariable.EnvironmentId, boTenantVariable.Id, boTenantVariable.JSON, boTenantVariable.OwnerId, boTenantVariable.RelatedDocumentId, boTenantVariable.TenantId, boTenantVariable.VariableTemplateId);

                        return model;
                }

                public virtual List<ApiTenantVariableResponseModel> MapBOToModel(
                        List<BOTenantVariable> items)
                {
                        List<ApiTenantVariableResponseModel> response = new List<ApiTenantVariableResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>08f9c5e3e50dba342cc85eb8b20d5034</Hash>
</Codenesium>*/