using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiWorkerResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string communicationStyle,
                        string fingerprint,
                        string id,
                        bool isDisabled,
                        string jSON,
                        string machinePolicyId,
                        string name,
                        string relatedDocumentIds,
                        string thumbprint,
                        string workerPoolIds)
                {
                        this.CommunicationStyle = communicationStyle;
                        this.Fingerprint = fingerprint;
                        this.Id = id;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.MachinePolicyId = machinePolicyId;
                        this.Name = name;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Thumbprint = thumbprint;
                        this.WorkerPoolIds = workerPoolIds;
                }

                public string CommunicationStyle { get; private set; }

                public string Fingerprint { get; private set; }

                public string Id { get; private set; }

                public bool IsDisabled { get; private set; }

                public string JSON { get; private set; }

                public string MachinePolicyId { get; private set; }

                public string Name { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public string Thumbprint { get; private set; }

                public string WorkerPoolIds { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCommunicationStyleValue { get; set; } = true;

                public bool ShouldSerializeCommunicationStyle()
                {
                        return this.ShouldSerializeCommunicationStyleValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeFingerprintValue { get; set; } = true;

                public bool ShouldSerializeFingerprint()
                {
                        return this.ShouldSerializeFingerprintValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIsDisabledValue { get; set; } = true;

                public bool ShouldSerializeIsDisabled()
                {
                        return this.ShouldSerializeIsDisabledValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMachinePolicyIdValue { get; set; } = true;

                public bool ShouldSerializeMachinePolicyId()
                {
                        return this.ShouldSerializeMachinePolicyIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRelatedDocumentIdsValue { get; set; } = true;

                public bool ShouldSerializeRelatedDocumentIds()
                {
                        return this.ShouldSerializeRelatedDocumentIdsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeThumbprintValue { get; set; } = true;

                public bool ShouldSerializeThumbprint()
                {
                        return this.ShouldSerializeThumbprintValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeWorkerPoolIdsValue { get; set; } = true;

                public bool ShouldSerializeWorkerPoolIds()
                {
                        return this.ShouldSerializeWorkerPoolIdsValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCommunicationStyleValue = false;
                        this.ShouldSerializeFingerprintValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIsDisabledValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeMachinePolicyIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeRelatedDocumentIdsValue = false;
                        this.ShouldSerializeThumbprintValue = false;
                        this.ShouldSerializeWorkerPoolIdsValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>4435f2137ac82d1d5d550f5c282fe59e</Hash>
</Codenesium>*/