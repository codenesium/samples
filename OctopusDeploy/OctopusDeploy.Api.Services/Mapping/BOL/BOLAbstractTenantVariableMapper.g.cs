using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>c594885fa89b922b3ec971f3e62146e5</Hash>
</Codenesium>*/