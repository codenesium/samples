using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPipelineStepNoteClientResponseModel : AbstractApiClientResponseModel
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

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string EmployeeIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public string PipelineStepIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>f5fa4a10bca4ce0e94a154877c915cab</Hash>
</Codenesium>*/