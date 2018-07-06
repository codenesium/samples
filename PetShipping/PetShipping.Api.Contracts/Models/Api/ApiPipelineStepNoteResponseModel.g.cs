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

                public int EmployeeId { get; private set; }

                public string EmployeeIdEntity { get; set; }

                public int Id { get; private set; }

                public string Note { get; private set; }

                public int PipelineStepId { get; private set; }

                public string PipelineStepIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>48867b41d674eac033173df6e4abd10c</Hash>
</Codenesium>*/