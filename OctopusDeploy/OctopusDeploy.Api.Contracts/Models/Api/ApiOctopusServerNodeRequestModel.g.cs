using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiOctopusServerNodeRequestModel : AbstractApiRequestModel
        {
                public ApiOctopusServerNodeRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        bool isInMaintenanceMode,
                        string jSON,
                        DateTimeOffset lastSeen,
                        int maxConcurrentTasks,
                        string name,
                        string rank)
                {
                        this.IsInMaintenanceMode = isInMaintenanceMode;
                        this.JSON = jSON;
                        this.LastSeen = lastSeen;
                        this.MaxConcurrentTasks = maxConcurrentTasks;
                        this.Name = name;
                        this.Rank = rank;
                }

                private bool isInMaintenanceMode;

                [Required]
                public bool IsInMaintenanceMode
                {
                        get
                        {
                                return this.isInMaintenanceMode;
                        }

                        set
                        {
                                this.isInMaintenanceMode = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private DateTimeOffset lastSeen;

                [Required]
                public DateTimeOffset LastSeen
                {
                        get
                        {
                                return this.lastSeen;
                        }

                        set
                        {
                                this.lastSeen = value;
                        }
                }

                private int maxConcurrentTasks;

                [Required]
                public int MaxConcurrentTasks
                {
                        get
                        {
                                return this.maxConcurrentTasks;
                        }

                        set
                        {
                                this.maxConcurrentTasks = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private string rank;

                [Required]
                public string Rank
                {
                        get
                        {
                                return this.rank;
                        }

                        set
                        {
                                this.rank = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>034d226b5ac576ed623b97bc217106ce</Hash>
</Codenesium>*/