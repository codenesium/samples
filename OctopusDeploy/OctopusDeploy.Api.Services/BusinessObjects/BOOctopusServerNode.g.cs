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
                                          DateTime lastSeen,
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

                public DateTime LastSeen { get; private set; }

                public int MaxConcurrentTasks { get; private set; }

                public string Name { get; private set; }

                public string Rank { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1b87bdc8be443f6882500cbe038c6ae2</Hash>
</Codenesium>*/