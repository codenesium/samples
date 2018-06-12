using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractOctopusServerNodeMapper
        {
                public virtual BOOctopusServerNode MapModelToBO(
                        string id,
                        ApiOctopusServerNodeRequestModel model
                        )
                {
                        BOOctopusServerNode boOctopusServerNode = new BOOctopusServerNode();

                        boOctopusServerNode.SetProperties(
                                id,
                                model.IsInMaintenanceMode,
                                model.JSON,
                                model.LastSeen,
                                model.MaxConcurrentTasks,
                                model.Name,
                                model.Rank);
                        return boOctopusServerNode;
                }

                public virtual ApiOctopusServerNodeResponseModel MapBOToModel(
                        BOOctopusServerNode boOctopusServerNode)
                {
                        var model = new ApiOctopusServerNodeResponseModel();

                        model.SetProperties(boOctopusServerNode.Id, boOctopusServerNode.IsInMaintenanceMode, boOctopusServerNode.JSON, boOctopusServerNode.LastSeen, boOctopusServerNode.MaxConcurrentTasks, boOctopusServerNode.Name, boOctopusServerNode.Rank);

                        return model;
                }

                public virtual List<ApiOctopusServerNodeResponseModel> MapBOToModel(
                        List<BOOctopusServerNode> items)
                {
                        List<ApiOctopusServerNodeResponseModel> response = new List<ApiOctopusServerNodeResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e21af825b693c61520d5fbbeb3e562ba</Hash>
</Codenesium>*/