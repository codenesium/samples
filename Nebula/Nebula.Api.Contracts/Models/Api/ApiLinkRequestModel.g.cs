using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiLinkRequestModel : AbstractApiRequestModel
        {
                public ApiLinkRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int? assignedMachineId,
                        int chainId,
                        DateTime? dateCompleted,
                        DateTime? dateStarted,
                        string dynamicParameters,
                        Guid externalId,
                        int linkStatusId,
                        string name,
                        int order,
                        string response,
                        string staticParameters,
                        int timeoutInSeconds)
                {
                        this.AssignedMachineId = assignedMachineId;
                        this.ChainId = chainId;
                        this.DateCompleted = dateCompleted;
                        this.DateStarted = dateStarted;
                        this.DynamicParameters = dynamicParameters;
                        this.ExternalId = externalId;
                        this.LinkStatusId = linkStatusId;
                        this.Name = name;
                        this.Order = order;
                        this.Response = response;
                        this.StaticParameters = staticParameters;
                        this.TimeoutInSeconds = timeoutInSeconds;
                }

                private int? assignedMachineId;

                public int? AssignedMachineId
                {
                        get
                        {
                                return this.assignedMachineId;
                        }

                        set
                        {
                                this.assignedMachineId = value;
                        }
                }

                private int chainId;

                [Required]
                public int ChainId
                {
                        get
                        {
                                return this.chainId;
                        }

                        set
                        {
                                this.chainId = value;
                        }
                }

                private DateTime? dateCompleted;

                public DateTime? DateCompleted
                {
                        get
                        {
                                return this.dateCompleted;
                        }

                        set
                        {
                                this.dateCompleted = value;
                        }
                }

                private DateTime? dateStarted;

                public DateTime? DateStarted
                {
                        get
                        {
                                return this.dateStarted;
                        }

                        set
                        {
                                this.dateStarted = value;
                        }
                }

                private string dynamicParameters;

                public string DynamicParameters
                {
                        get
                        {
                                return this.dynamicParameters;
                        }

                        set
                        {
                                this.dynamicParameters = value;
                        }
                }

                private Guid externalId;

                [Required]
                public Guid ExternalId
                {
                        get
                        {
                                return this.externalId;
                        }

                        set
                        {
                                this.externalId = value;
                        }
                }

                private int linkStatusId;

                [Required]
                public int LinkStatusId
                {
                        get
                        {
                                return this.linkStatusId;
                        }

                        set
                        {
                                this.linkStatusId = value;
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

                private int order;

                [Required]
                public int Order
                {
                        get
                        {
                                return this.order;
                        }

                        set
                        {
                                this.order = value;
                        }
                }

                private string response;

                public string Response
                {
                        get
                        {
                                return this.response;
                        }

                        set
                        {
                                this.response = value;
                        }
                }

                private string staticParameters;

                public string StaticParameters
                {
                        get
                        {
                                return this.staticParameters;
                        }

                        set
                        {
                                this.staticParameters = value;
                        }
                }

                private int timeoutInSeconds;

                [Required]
                public int TimeoutInSeconds
                {
                        get
                        {
                                return this.timeoutInSeconds;
                        }

                        set
                        {
                                this.timeoutInSeconds = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>16688b7cfd1d5bf2ef563d9f07cf2524</Hash>
</Codenesium>*/