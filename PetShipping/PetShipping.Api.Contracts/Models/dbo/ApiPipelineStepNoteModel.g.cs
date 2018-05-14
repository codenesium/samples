using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineStepNoteModel
	{
		public ApiPipelineStepNoteModel()
		{}

		public ApiPipelineStepNoteModel(
			int employeeId,
			string note,
			int pipelineStepId)
		{
			this.EmployeeId = employeeId.ToInt();
			this.Note = note.ToString();
			this.PipelineStepId = pipelineStepId.ToInt();
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
    <Hash>131f5f821c8c0ce0d7e3f4f589761480</Hash>
</Codenesium>*/