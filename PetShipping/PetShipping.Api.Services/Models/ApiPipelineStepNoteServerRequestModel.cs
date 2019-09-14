using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineStepNoteServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPipelineStepNoteServerRequestModel()
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
		public int EmployeeId { get; private set; }

		[Required]
		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a0cf1fd3b62fe358cb19f02ff69ca2eb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/