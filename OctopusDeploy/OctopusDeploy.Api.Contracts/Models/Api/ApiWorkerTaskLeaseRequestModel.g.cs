using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiWorkerTaskLeaseRequestModel: AbstractApiRequestModel
        {
                public ApiWorkerTaskLeaseRequestModel() : base()
                {
                }

                public void SetProperties(
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

                private bool exclusive;

                [Required]
                public bool Exclusive
                {
                        get
                        {
                                return this.exclusive;
                        }

                        set
                        {
                                this.exclusive = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
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

                private string taskId;

                [Required]
                public string TaskId
                {
                        get
                        {
                                return this.taskId;
                        }

                        set
                        {
                                this.taskId = value;
                        }
                }

                private string workerId;

                [Required]
                public string WorkerId
                {
                        get
                        {
                                return this.workerId;
                        }

                        set
                        {
                                this.workerId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b758514e03888a5c80671d383faa960b</Hash>
</Codenesium>*/