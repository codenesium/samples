using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractOctopusServerNodeMapper
        {
                public virtual OctopusServerNode MapBOToEF(
                        BOOctopusServerNode bo)
                {
                        OctopusServerNode efOctopusServerNode = new OctopusServerNode();
                        efOctopusServerNode.SetProperties(
                                bo.Id,
                                bo.IsInMaintenanceMode,
                                bo.JSON,
                                bo.LastSeen,
                                bo.MaxConcurrentTasks,
                                bo.Name,
                                bo.Rank);
                        return efOctopusServerNode;
                }

                public virtual BOOctopusServerNode MapEFToBO(
                        OctopusServerNode ef)
                {
                        var bo = new BOOctopusServerNode();

                        bo.SetProperties(
                                ef.Id,
                                ef.IsInMaintenanceMode,
                                ef.JSON,
                                ef.LastSeen,
                                ef.MaxConcurrentTasks,
                                ef.Name,
                                ef.Rank);
                        return bo;
                }

                public virtual List<BOOctopusServerNode> MapEFToBO(
                        List<OctopusServerNode> records)
                {
                        List<BOOctopusServerNode> response = new List<BOOctopusServerNode>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2eaaad838d8779d381eb284b6a04b0c1</Hash>
</Codenesium>*/