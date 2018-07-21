using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiWorkerTaskLeaseResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        bool exclusive,
                        string jSON,
                        string name,
                        string taskId,
                        string workerId)
                {
                        this.Id = id;
                        this.Exclusive = exclusive;
                        this.JSON = jSON;
                        this.Name = name;
                        this.TaskId = taskId;
                        this.WorkerId = workerId;
                }

                [Required]
                [JsonProperty]
                public bool Exclusive { get; private set; }

                [Required]
                [JsonProperty]
                public string Id { get; private set; }

                [Required]
                [JsonProperty]
                public string JSON { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public string TaskId { get; private set; }

                [Required]
                [JsonProperty]
                public string WorkerId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a81c14a656df3865f2bf402007b5b221</Hash>
</Codenesium>*/