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
                        int? assignedMachineId,
                        int chainId,
                        DateTime? dateCompleted,
                        DateTime? dateStarted,
                        string dynamicParameters,
                        Guid externalId,
                        int id,
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

                [JsonIgnore]
                public bool ShouldSerializeAssignedMachineIdValue { get; set; } = true;

                public bool ShouldSerializeAssignedMachineId()
                {
                        return this.ShouldSerializeAssignedMachineIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeChainIdValue { get; set; } = true;

                public bool ShouldSerializeChainId()
                {
                        return this.ShouldSerializeChainIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDateCompletedValue { get; set; } = true;

                public bool ShouldSerializeDateCompleted()
                {
                        return this.ShouldSerializeDateCompletedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDateStartedValue { get; set; } = true;

                public bool ShouldSerializeDateStarted()
                {
                        return this.ShouldSerializeDateStartedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDynamicParametersValue { get; set; } = true;

                public bool ShouldSerializeDynamicParameters()
                {
                        return this.ShouldSerializeDynamicParametersValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeExternalIdValue { get; set; } = true;

                public bool ShouldSerializeExternalId()
                {
                        return this.ShouldSerializeExternalIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLinkStatusIdValue { get; set; } = true;

                public bool ShouldSerializeLinkStatusId()
                {
                        return this.ShouldSerializeLinkStatusIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOrderValue { get; set; } = true;

                public bool ShouldSerializeOrder()
                {
                        return this.ShouldSerializeOrderValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeResponseValue { get; set; } = true;

                public bool ShouldSerializeResponse()
                {
                        return this.ShouldSerializeResponseValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStaticParametersValue { get; set; } = true;

                public bool ShouldSerializeStaticParameters()
                {
                        return this.ShouldSerializeStaticParametersValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTimeoutInSecondsValue { get; set; } = true;

                public bool ShouldSerializeTimeoutInSeconds()
                {
                        return this.ShouldSerializeTimeoutInSecondsValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAssignedMachineIdValue = false;
                        this.ShouldSerializeChainIdValue = false;
                        this.ShouldSerializeDateCompletedValue = false;
                        this.ShouldSerializeDateStartedValue = false;
                        this.ShouldSerializeDynamicParametersValue = false;
                        this.ShouldSerializeExternalIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLinkStatusIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeOrderValue = false;
                        this.ShouldSerializeResponseValue = false;
                        this.ShouldSerializeStaticParametersValue = false;
                        this.ShouldSerializeTimeoutInSecondsValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>ba10a10f4436027caaa220efb5bc4037</Hash>
</Codenesium>*/