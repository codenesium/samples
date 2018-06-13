using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOOctopusServerNode: AbstractBusinessObject
        {
                public BOOctopusServerNode() : base()
                {
                }

                public void SetProperties(string id,
                                          bool isInMaintenanceMode,
                                          string jSON,
                                          DateTimeOffset lastSeen,
                                          int maxConcurrentTasks,
                                          string name,
                                          string rank)
                {
                        this.Id = id;
                        this.IsInMaintenanceMode = isInMaintenanceMode;
                        this.JSON = jSON;
                        this.LastSeen = lastSeen;
                        this.MaxConcurrentTasks = maxConcurrentTasks;
                        this.Name = name;
                        this.Rank = rank;
                }

                public string Id { get; private set; }

                public bool IsInMaintenanceMode { get; private set; }

                public string JSON { get; private set; }

                public DateTimeOffset LastSeen { get; private set; }

                public int MaxConcurrentTasks { get; private set; }

                public string Name { get; private set; }

                public string Rank { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b3788528d4d655a522049c3edcf60bd8</Hash>
</Codenesium>*/