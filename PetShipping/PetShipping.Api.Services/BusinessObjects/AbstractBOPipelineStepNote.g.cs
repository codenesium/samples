using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOPipelineStepNote : AbstractBusinessObject
	{
		public AbstractBOPipelineStepNote()
			: base()
		{
		}

		public virtual void SetProperties(int id,
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
    <Hash>dddbb5bcea5768072afb0d474fbd2685</Hash>
</Codenesium>*/