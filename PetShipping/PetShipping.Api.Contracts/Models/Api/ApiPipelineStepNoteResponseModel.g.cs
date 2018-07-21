using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepNoteResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int employeeId,
                        string note,
                        int pipelineStepId)
                {
                        this.Id = id;
                        this.EmployeeId = employeeId;
                        this.Note = note;
                        this.PipelineStepId = pipelineStepId;

                        this.EmployeeIdEntity = nameof(ApiResponse.Employees);
                        this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
                }

                [Required]
                [JsonProperty]
                public int EmployeeId { get; private set; }

                [JsonProperty]
                public string EmployeeIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Note { get; private set; }

                [Required]
                [JsonProperty]
                public int PipelineStepId { get; private set; }

                [JsonProperty]
                public string PipelineStepIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>2282bc5e375889c588402787f28dd985</Hash>
</Codenesium>*/