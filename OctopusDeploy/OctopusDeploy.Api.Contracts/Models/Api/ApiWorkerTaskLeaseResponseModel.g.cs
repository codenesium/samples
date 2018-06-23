using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public class ApiWorkerTaskLeaseResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        bool exclusive,
                        string id,
                        string jSON,
                        string name,
                        string taskId,
                        string workerId)
                {
                        this.Exclusive = exclusive;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.TaskId = taskId;
                        this.WorkerId = workerId;
                }

                public bool Exclusive { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string TaskId { get; private set; }

                public string WorkerId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeExclusiveValue { get; set; } = true;

                public bool ShouldSerializeExclusive()
                {
                        return this.ShouldSerializeExclusiveValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJSONValue { get; set; } = true;

                public bool ShouldSerializeJSON()
                {
                        return this.ShouldSerializeJSONValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTaskIdValue { get; set; } = true;

                public bool ShouldSerializeTaskId()
                {
                        return this.ShouldSerializeTaskIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeWorkerIdValue { get; set; } = true;

                public bool ShouldSerializeWorkerId()
                {
                        return this.ShouldSerializeWorkerIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeExclusiveValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJSONValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeTaskIdValue = false;
                        this.ShouldSerializeWorkerIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>1b1e8b6ec0931c543bcd9a2bb3122b7e</Hash>
</Codenesium>*/