using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
                        Nullable<int> assignedMachineId,
                        int chainId,
                        Nullable<DateTime> dateCompleted,
                        Nullable<DateTime> dateStarted,
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

                private Nullable<int> assignedMachineId;

                public Nullable<int> AssignedMachineId
                {
                        get
                        {
                                return this.assignedMachineId.IsEmptyOrZeroOrNull() ? null : this.assignedMachineId;
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

                private Nullable<DateTime> dateCompleted;

                public Nullable<DateTime> DateCompleted
                {
                        get
                        {
                                return this.dateCompleted.IsEmptyOrZeroOrNull() ? null : this.dateCompleted;
                        }

                        set
                        {
                                this.dateCompleted = value;
                        }
                }

                private Nullable<DateTime> dateStarted;

                public Nullable<DateTime> DateStarted
                {
                        get
                        {
                                return this.dateStarted.IsEmptyOrZeroOrNull() ? null : this.dateStarted;
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
                                return this.dynamicParameters.IsEmptyOrZeroOrNull() ? null : this.dynamicParameters;
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
                                return this.response.IsEmptyOrZeroOrNull() ? null : this.response;
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
                                return this.staticParameters.IsEmptyOrZeroOrNull() ? null : this.staticParameters;
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
    <Hash>b0e971995d986a2b44683f5116364316</Hash>
</Codenesium>*/