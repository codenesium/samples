using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepNoteResponseModel: AbstractApiResponseModel
	{
		public ApiPipelineStepNoteResponseModel() : base()
		{}

		public void SetProperties(
			int employeeId,
			int id,
			string note,
			int pipelineStepId)
		{
			this.EmployeeId = employeeId.ToInt();
			this.Id = id.ToInt();
			this.Note = note;
			this.PipelineStepId = pipelineStepId.ToInt();

			this.EmployeeIdEntity = nameof(ApiResponse.Employees);
			this.PipelineStepIdEntity = nameof(ApiResponse.PipelineSteps);
		}

		public int EmployeeId { get; private set; }
		public string EmployeeIdEntity { get; set; }
		public int Id { get; private set; }
		public string Note { get; private set; }
		public int PipelineStepId { get; private set; }
		public string PipelineStepIdEntity { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeEmployeeIdValue { get; set; } = true;

		public bool ShouldSerializeEmployeeId()
		{
			return this.ShouldSerializeEmployeeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNoteValue { get; set; } = true;

		public bool ShouldSerializeNote()
		{
			return this.ShouldSerializeNoteValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStepIdValue { get; set; } = true;

		public bool ShouldSerializePipelineStepId()
		{
			return this.ShouldSerializePipelineStepIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeEmployeeIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNoteValue = false;
			this.ShouldSerializePipelineStepIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>f502990d1db687f7a1aa586ba11d894f</Hash>
</Codenesium>*/