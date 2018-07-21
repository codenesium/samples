using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiWorkerTaskLeaseRequestModel : AbstractApiRequestModel
        {
                public ApiWorkerTaskLeaseRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        bool exclusive,
                        string jSON,
                        string name,
                        string taskId,
                        string workerId)
                {
                        this.Exclusive = exclusive;
                        this.JSON = jSON;
                        this.Name = name;
                        this.TaskId = taskId;
                        this.WorkerId = workerId;
                }

                [JsonProperty]
                public bool Exclusive { get; private set; }

                [JsonProperty]
                public string JSON { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public string TaskId { get; private set; }

                [JsonProperty]
                public string WorkerId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>71bc570ad316ab2d4fb3ac389c874bff</Hash>
</Codenesium>*/