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

		[Required]
		[JsonProperty]
		public int EmployeeId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>626fa80374b71875928b55b7ad521b64</Hash>
</Codenesium>*/