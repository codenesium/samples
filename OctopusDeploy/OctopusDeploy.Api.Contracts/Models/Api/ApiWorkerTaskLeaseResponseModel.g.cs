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

                public bool Exclusive { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string TaskId { get; private set; }

                public string WorkerId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b85e6a1739668e5deb6fdbaffc3d1b9a</Hash>
</Codenesium>*/