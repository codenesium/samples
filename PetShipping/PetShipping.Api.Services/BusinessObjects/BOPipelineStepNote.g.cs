using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOPipelineStepNote: AbstractBusinessObject
        {
                public BOPipelineStepNote() : base()
                {
                }

                public void SetProperties(int id,
                                          int employeeId,
                                          string note,
                                          int pipelineStepId)
                {
                        this.EmployeeId = employeeId;
                        this.Id = id;
                        this.Note = note;
                        this.PipelineStepId = pipelineStepId;
                }

                public int EmployeeId { get; private set; }

                public int Id { get; private set; }

                public string Note { get; private set; }

                public int PipelineStepId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5d220385d6028fb52513df7dbb92ab7b</Hash>
</Codenesium>*/