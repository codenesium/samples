using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineStepNoteServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string EmployeeIdEntity { get; private set; } = RouteConstants.Employees;

		[JsonProperty]
		public ApiEmployeeServerResponseModel EmployeeIdNavigation { get; private set; }

		public void SetEmployeeIdNavigation(ApiEmployeeServerResponseModel value)
		{
			this.EmployeeIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public int PipelineStepId { get; private set; }

		[JsonProperty]
		public string PipelineStepIdEntity { get; private set; } = RouteConstants.PipelineSteps;

		[JsonProperty]
		public ApiPipelineStepServerResponseModel PipelineStepIdNavigation { get; private set; }

		public void SetPipelineStepIdNavigation(ApiPipelineStepServerResponseModel value)
		{
			this.PipelineStepIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>5da3465277439e329ce6a42127de9759</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/