using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>b85e4daf94cdcf3c41167656a123f394</Hash>
</Codenesium>*/