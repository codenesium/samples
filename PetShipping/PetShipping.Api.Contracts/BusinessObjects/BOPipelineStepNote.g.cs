using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class BOPipelineStepNote: AbstractBusinessObject
	{
		public BOPipelineStepNote() : base()
		{}

		public void SetProperties(int id,
		                          int employeeId,
		                          string note,
		                          int pipelineStepId)
		{
			this.EmployeeId = employeeId.ToInt();
			this.Id = id.ToInt();
			this.Note = note;
			this.PipelineStepId = pipelineStepId.ToInt();
		}

		public int EmployeeId { get; private set; }
		public int Id { get; private set; }
		public string Note { get; private set; }
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>64c250dce137c3978b36fee85c526322</Hash>
</Codenesium>*/