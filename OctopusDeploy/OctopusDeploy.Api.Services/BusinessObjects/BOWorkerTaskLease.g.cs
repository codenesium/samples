using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOWorkerTaskLease: AbstractBusinessObject
        {
                public BOWorkerTaskLease() : base()
                {
                }

                public void SetProperties(string id,
                                          bool exclusive,
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
        }
}

/*<Codenesium>
    <Hash>629bcb9ab8f78b2de075a25f861a2028</Hash>
</Codenesium>*/