using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiLinkResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
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
                        this.Id = id;
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

                        this.AssignedMachineIdEntity = nameof(ApiResponse.Machines);
                        this.ChainIdEntity = nameof(ApiResponse.Chains);
                        this.LinkStatusIdEntity = nameof(ApiResponse.LinkStatus);
                }

                public int? AssignedMachineId { get; private set; }

                public string AssignedMachineIdEntity { get; set; }

                public int ChainId { get; private set; }

                public string ChainIdEntity { get; set; }

                public DateTime? DateCompleted { get; private set; }

                public DateTime? DateStarted { get; private set; }

                public string DynamicParameters { get; private set; }

                public Guid ExternalId { get; private set; }

                public int Id { get; private set; }

                public int LinkStatusId { get; private set; }

                public string LinkStatusIdEntity { get; set; }

                public string Name { get; private set; }

                public int Order { get; private set; }

                public string Response { get; private set; }

                public string StaticParameters { get; private set; }

                public int TimeoutInSeconds { get; private set; }
        }
}

/*<Codenesium>
    <Hash>728cf18ced8a2ff1b7f14e19910362b7</Hash>
</Codenesium>*/