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
			this.Id = id.ToInt();
			this.Note = note;

			this.EmployeeId = new ReferenceEntity<int>(employeeId,
			                                           nameof(ApiResponse.Employees));
			this.PipelineStepId = new ReferenceEntity<int>(pipelineStepId,
			                                               nameof(ApiResponse.PipelineSteps));
		}

		public ReferenceEntity<int> EmployeeId { get; set; }
		public int Id { get; set; }
		public string Note { get; set; }
		public ReferenceEntity<int> PipelineStepId { get; set; }

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
    <Hash>ca343b137bc2591d77bd0290f6d1d6f5</Hash>
</Codenesium>*/