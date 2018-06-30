using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiPipelineStepNoteRequestModel : AbstractApiRequestModel
        {
                public ApiPipelineStepNoteRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int employeeId,
                        string note,
                        int pipelineStepId)
                {
                        this.EmployeeId = employeeId;
                        this.Note = note;
                        this.PipelineStepId = pipelineStepId;
                }

                private int employeeId;

                [Required]
                public int EmployeeId
                {
                        get
                        {
                                return this.employeeId;
                        }

                        set
                        {
                                this.employeeId = value;
                        }
                }

                private string note;

                [Required]
                public string Note
                {
                        get
                        {
                                return this.note;
                        }

                        set
                        {
                                this.note = value;
                        }
                }

                private int pipelineStepId;

                [Required]
                public int PipelineStepId
                {
                        get
                        {
                                return this.pipelineStepId;
                        }

                        set
                        {
                                this.pipelineStepId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>381ff1f470438f2c1d976c78e431a493</Hash>
</Codenesium>*/