using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPipelineStepNoteClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPipelineStepNoteClientRequestModel()
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

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[JsonProperty]
		public int PipelineStepId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c1480a2fb75859f78bc46ee0d96f47fc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/