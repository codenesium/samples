using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOPipelineStepNote: AbstractDTO
	{
		public DTOPipelineStepNote() : base()
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

		public int EmployeeId { get; set; }
		public int Id { get; set; }
		public string Note { get; set; }
		public int PipelineStepId { get; set; }
	}
}

/*<Codenesium>
    <Hash>acc3eff8284b048afafa4879d86cb9f9</Hash>
</Codenesium>*/