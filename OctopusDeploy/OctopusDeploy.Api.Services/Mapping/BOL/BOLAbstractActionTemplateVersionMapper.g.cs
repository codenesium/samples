using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractActionTemplateVersionMapper
        {
                public virtual BOActionTemplateVersion MapModelToBO(
                        string id,
                        ApiActionTemplateVersionRequestModel model
                        )
                {
                        BOActionTemplateVersion boActionTemplateVersion = new BOActionTemplateVersion();
                        boActionTemplateVersion.SetProperties(
                                id,
                                model.ActionType,
                                model.JSON,
                                model.LatestActionTemplateId,
                                model.Name,
                                model.Version);
                        return boActionTemplateVersion;
                }

                public virtual ApiActionTemplateVersionResponseModel MapBOToModel(
                        BOActionTemplateVersion boActionTemplateVersion)
                {
                        var model = new ApiActionTemplateVersionResponseModel();

                        model.SetProperties(boActionTemplateVersion.ActionType, boActionTemplateVersion.Id, boActionTemplateVersion.JSON, boActionTemplateVersion.LatestActionTemplateId, boActionTemplateVersion.Name, boActionTemplateVersion.Version);

                        return model;
                }

                public virtual List<ApiActionTemplateVersionResponseModel> MapBOToModel(
                        List<BOActionTemplateVersion> items)
                {
                        List<ApiActionTemplateVersionResponseModel> response = new List<ApiActionTemplateVersionResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ec1af0bec94a785f264bd3c32c1254aa</Hash>
</Codenesium>*/