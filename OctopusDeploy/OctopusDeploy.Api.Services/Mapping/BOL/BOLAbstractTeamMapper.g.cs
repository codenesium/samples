using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractTeamMapper
        {
                public virtual BOTeam MapModelToBO(
                        string id,
                        ApiTeamRequestModel model
                        )
                {
                        BOTeam boTeam = new BOTeam();
                        boTeam.SetProperties(
                                id,
                                model.EnvironmentIds,
                                model.JSON,
                                model.MemberUserIds,
                                model.Name,
                                model.ProjectGroupIds,
                                model.ProjectIds,
                                model.TenantIds,
                                model.TenantTags);
                        return boTeam;
                }

                public virtual ApiTeamResponseModel MapBOToModel(
                        BOTeam boTeam)
                {
                        var model = new ApiTeamResponseModel();

                        model.SetProperties(boTeam.EnvironmentIds, boTeam.Id, boTeam.JSON, boTeam.MemberUserIds, boTeam.Name, boTeam.ProjectGroupIds, boTeam.ProjectIds, boTeam.TenantIds, boTeam.TenantTags);

                        return model;
                }

                public virtual List<ApiTeamResponseModel> MapBOToModel(
                        List<BOTeam> items)
                {
                        List<ApiTeamResponseModel> response = new List<ApiTeamResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>08f7c2dbe9b248303c1bfdadb5fd153b</Hash>
</Codenesium>*/