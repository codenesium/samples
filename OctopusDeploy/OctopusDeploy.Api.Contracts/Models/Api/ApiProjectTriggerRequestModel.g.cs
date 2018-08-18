using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiProjectTriggerRequestModel : AbstractApiRequestModel
	{
		public ApiProjectTriggerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			bool isDisabled,
			string jSON,
			string name,
			string projectId,
			string triggerType)
		{
			this.IsDisabled = isDisabled;
			this.JSON = jSON;
			this.Name = name;
			this.ProjectId = projectId;
			this.TriggerType = triggerType;
		}

		[JsonProperty]
		public bool IsDisabled { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string ProjectId { get; private set; }

		[JsonProperty]
		public string TriggerType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f6b6d4a4bcec198e3c612ffa7a54e3e0</Hash>
</Codenesium>*/