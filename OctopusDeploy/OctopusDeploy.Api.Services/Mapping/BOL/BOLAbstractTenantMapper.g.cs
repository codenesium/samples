using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractTenantMapper
        {
                public virtual BOTenant MapModelToBO(
                        string id,
                        ApiTenantRequestModel model
                        )
                {
                        BOTenant boTenant = new BOTenant();
                        boTenant.SetProperties(
                                id,
                                model.DataVersion,
                                model.JSON,
                                model.Name,
                                model.ProjectIds,
                                model.TenantTags);
                        return boTenant;
                }

                public virtual ApiTenantResponseModel MapBOToModel(
                        BOTenant boTenant)
                {
                        var model = new ApiTenantResponseModel();

                        model.SetProperties(boTenant.DataVersion, boTenant.Id, boTenant.JSON, boTenant.Name, boTenant.ProjectIds, boTenant.TenantTags);

                        return model;
                }

                public virtual List<ApiTenantResponseModel> MapBOToModel(
                        List<BOTenant> items)
                {
                        List<ApiTenantResponseModel> response = new List<ApiTenantResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c2ddc1be2ffe818dab1f6f9e7e7245e1</Hash>
</Codenesium>*/