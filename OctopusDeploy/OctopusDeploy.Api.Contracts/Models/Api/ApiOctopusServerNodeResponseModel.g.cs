using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiOctopusServerNodeResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
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
    <Hash>8e5e2d3b80578a60576b9050abd5b5a7</Hash>
</Codenesium>*/