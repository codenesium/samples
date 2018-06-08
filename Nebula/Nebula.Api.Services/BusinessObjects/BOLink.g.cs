using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
        public partial class BOLink:AbstractBusinessObject
        {
                public BOLink() : base()
                {
                }

                public void SetProperties(int id,
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
                        this.Id = id;
                        this.LinkStatusId = linkStatusId;
                        this.Name = name;
                        this.Order = order;
                        this.Response = response;
                        this.StaticParameters = staticParameters;
                        this.TimeoutInSeconds = timeoutInSeconds;
                }

                public Nullable<int> AssignedMachineId { get; private set; }

                public int ChainId { get; private set; }

                public Nullable<DateTime> DateCompleted { get; private set; }

                public Nullable<DateTime> DateStarted { get; private set; }

                public string DynamicParameters { get; private set; }

                public Guid ExternalId { get; private set; }

                public int Id { get; private set; }

                public int LinkStatusId { get; private set; }

                public string Name { get; private set; }

                public int Order { get; private set; }

                public string Response { get; private set; }

                public string StaticParameters { get; private set; }

                public int TimeoutInSeconds { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b8d3b97d7a48c841be9e41cc092823c5</Hash>
</Codenesium>*/