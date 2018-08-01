using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiProjectTriggerResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			bool isDisabled,
			string jSON,
			string name,
			string projectId,
			string triggerType)
		{
			this.Id = id;
			this.IsDisabled = isDisabled;
			this.JSON = jSON;
			this.Name = name;
			this.ProjectId = projectId;
			this.TriggerType = triggerType;
		}

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public bool IsDisabled { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string ProjectId { get; private set; }

		[Required]
		[JsonProperty]
		public string TriggerType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a686cbab71d4b59539ecfd4f8fd25f99</Hash>
</Codenesium>*/